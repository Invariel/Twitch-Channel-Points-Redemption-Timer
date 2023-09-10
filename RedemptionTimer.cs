using Microsoft.Extensions.Configuration;
using Microsoft.Win32;
using System.ComponentModel;
using System.Text.Json;
using System.Timers;
using Twitch_Channel_Points_Redemption_Timer.Models;
using TwitchLib.PubSub.Interfaces;

using LocalRedemption = Twitch_Channel_Points_Redemption_Timer.Models.Redemption;
using Timer = System.Timers.Timer;

// Webauth URL: https://invariel.ca/webauth/twitch_auth.html
// Client ID: arjb0z5kjqs974gbwblt8aryaugvmc

namespace Twitch_Channel_Points_Redemption_Timer
{
    public partial class RedemptionTimer : Form
    {
        private ITwitchPubSub _twitchPubSub;
        private TwitchLib.Api.Helix.Helix _twitchAPI;

        // ([ "group": ({ { "name"; "duration" }, { "name"; "duration" }, ... }) ]);
        internal Dictionary<string, List<TimedRedemption>> _timers = new Dictionary<string, List<TimedRedemption>>(StringComparer.InvariantCultureIgnoreCase);
        private Timer _timer;
        private TimeSpan _updateInterval = new TimeSpan(0, 0, 0, 0, 100);

        internal BindingList<LocalRedemption> _redemptions = new BindingList<LocalRedemption>();
        private string outputFilename;
        private FileStream outputFile;

        private TwitchConnection _twitchConnection;

        private bool _bindingRedemptions = false;

        public RedemptionTimer(ITwitchPubSub pubsub, IConfiguration configuration)
        {
            _twitchConnection = new TwitchConnection();
            configuration.GetRequiredSection("Twitch").Bind(_twitchConnection);

            _twitchAPI = new TwitchLib.Api.Helix.Helix();
            _twitchAPI.Settings.ClientId = "hw23lau0o8duwhk5h3wgpal4mbznyl";
            _twitchAPI.Settings.AccessToken = _twitchConnection.OAuthToken;
            var userIds = _twitchAPI.Users.GetUsersAsync(logins: new List<string>() { _twitchConnection.ChannelName }).GetAwaiter().GetResult();
            _twitchConnection.ChannelId = userIds.Users[0].Id;

            _twitchPubSub = pubsub;

            _twitchPubSub.OnChannelPointsRewardRedeemed += _twitchPubSub_OnChannelPointsRewardRedeemed;
            _twitchPubSub.OnPubSubServiceConnected += _twitchPubSub_OnPubSubServiceConnected;
            _twitchPubSub.OnPubSubServiceError += _twitchPubSub_OnPubSubServiceError;

            _twitchPubSub.ListenToChannelPoints(_twitchConnection.ChannelId);
            _twitchPubSub.Connect();

            Output output = new Output();
            configuration.GetRequiredSection("Output").Bind(output);

            outputFilename = output.OutputFile;
            _redemptions = new BindingList<LocalRedemption>(output.Redemptions);

            InitializeComponent();

            _redemptions.AllowNew = true;
            _redemptions.AllowEdit = true;
            _redemptions.AllowRemove = true;
            _redemptions.ListChanged += SaveRedemptions;

            dg_Redemptions.DataSource = _redemptions;
            dg_Redemptions.CellValidating += ValidateTimeSpan;

            UpdateSettingsFields();
            UpdateRedemptions();

            _timer = new Timer();
            _timer.Interval = _updateInterval.TotalMilliseconds;
            _timer.Elapsed += UpdateTimes;
            _timer.Start();

            outputFile = File.Open(outputFilename, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.Read);
        }

        private void UpdateSettingsFields()
        {
            txt_Username.Text = _twitchConnection.ChannelName;
            txt_UserId.Text = _twitchConnection.ChannelId;
            txt_OAuth.Text = _twitchConnection.OAuthToken;
            txt_OutputFileName.Text = outputFilename;
        }

        private void UpdateRedemptions()
        {
            dg_Redemptions.Columns["Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dg_Redemptions.Columns["Duration"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dg_Redemptions.Columns["Group"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dg_Redemptions.Columns["UseMessage"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            dg_Redemptions.Columns["Enabled"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
        }

        private void ValidateTimeSpan(object? sender, DataGridViewCellValidatingEventArgs e)
        {
            if (dg_Redemptions.Columns[e.ColumnIndex].Name == "Duration")
            {
                if (!TimeSpan.TryParse(e.FormattedValue?.ToString() ?? "00:00:00", out TimeSpan _))
                {
                    MessageBox.Show("Duration must be in the form hh:mm:ss, with at least two digits per unit.");
                    e.Cancel = true;
                }
            }
        }

        private void SaveRedemptions(object? sender, EventArgs? e)
        {
            if (!_bindingRedemptions)
            {
                _bindingRedemptions = true;

                Output output = new Output();
                output.OutputFile = outputFilename;
                output.Redemptions = _redemptions.ToList<LocalRedemption>();

                output.Redemptions.RemoveAll(r => string.IsNullOrEmpty(r.Name));

                string serializedRedemptions = JsonSerializer.Serialize(output, new JsonSerializerOptions()
                {
                    WriteIndented = true
                });

                serializedRedemptions = $"{{ \"Output\": {serializedRedemptions} }}";

                File.WriteAllText("AppSettings.json", serializedRedemptions);

                _bindingRedemptions = false;
            }
        }

        private void _twitchPubSub_OnPubSubServiceConnected(object? sender, EventArgs? e)
        {
            Console.WriteLine("Connected to Twitch PubSub.");
            _twitchPubSub.SendTopics(_twitchConnection.OAuthToken);
        }

        private void _twitchPubSub_OnPubSubServiceError(object? sender, EventArgs? e)
        {
            Console.WriteLine("Error in connecting to Twitch.  Inspect 'e'.");
        }

        private void _twitchPubSub_OnChannelPointsRewardRedeemed(object? sender, TwitchLib.PubSub.Events.OnChannelPointsRewardRedeemedArgs e)
        {
            LocalRedemption? redemption = _redemptions.FirstOrDefault(r => r.Name.Equals(e.RewardRedeemed.Redemption.Reward.Title, StringComparison.OrdinalIgnoreCase) && r.Enabled);

            if (redemption is not null)
            {
                string groupName = redemption.Group.Trim();
                string key = redemption.UseMessage ? e.RewardRedeemed.Redemption.UserInput : e.RewardRedeemed.Redemption.Reward.Title;

                if (_timers.ContainsKey(groupName))
                {
                    var existingRedemption = _timers[groupName].FirstOrDefault(r => r.Name.Equals(key, StringComparison.OrdinalIgnoreCase));

                    if (existingRedemption is null)
                    {
                        _timers[groupName].Add(new TimedRedemption { Name = key, Duration = redemption.Duration });
                    }
                    else
                    {
                        existingRedemption.Duration = existingRedemption.Duration + redemption.Duration;
                    }
                }
                else
                {
                    _timers.Add(groupName, new List<TimedRedemption>() { new TimedRedemption { Name = key, Duration = redemption.Duration } } );
                }
            }
        }

        /// <summary></summary>
        /// <param name="redemption"></param>
        /// <returns>True if the redemption has time remaining, false otherwise.</returns>
        private bool UpdateRedemption(ref TimedRedemption redemption)
        {
            redemption.Duration = redemption.Duration.Subtract(_updateInterval);
            return redemption.Duration > TimeSpan.Zero;
        }

        private void UpdateGroup(string group)
        {
            if (string.IsNullOrEmpty(group))
            {
                _timers[group] = _timers[group].Where(r => UpdateRedemption(ref r)).ToList();
            }
            else
            {
                TimedRedemption firstRedemption = _timers[group].First();
                if (!UpdateRedemption(ref firstRedemption))
                {
                    _timers[group].Remove(firstRedemption);
                }
            }
        }

        private void UpdateTimes(object? sender, ElapsedEventArgs _)
        {
            foreach (string groupName in _timers.Keys)
            {
                UpdateGroup(groupName);

                if (_timers[groupName].Count == 0)
                {
                    _timers.Remove(groupName);
                }
            }

            string outputString = "";

            foreach (string groupName in _timers.Keys)
            {
                outputString += $"{groupName}{Environment.NewLine}";

                _timers[groupName].ForEach(r =>
                {
                    string curString = r.Name + " - ";

                    if (r.Duration.Hours > 0) { curString += r.Duration.ToString(@"h\:mm\:ss"); }
                    else { curString += r.Duration.ToString(@"m\:ss"); }
                    outputString += $"{curString}{Environment.NewLine}";
                });

                outputString += Environment.NewLine;
            }

            outputFile.Position = 0;
            outputFile.SetLength(0);
            outputFile.Write(System.Text.Encoding.GetEncoding("UTF-8").GetBytes(outputString), 0, outputString.Length);
            outputFile.Flush();
        }
    }
}