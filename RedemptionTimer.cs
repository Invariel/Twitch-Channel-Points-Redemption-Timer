using Microsoft.Extensions.Configuration;
using System.ComponentModel;
using System.Text.Json;
using Twitch_Channel_Points_Redemption_Timer.Models;
using TwitchLib.PubSub.Interfaces;

using LocalRedemption = Twitch_Channel_Points_Redemption_Timer.Models.Redemption;

// Webauth URL: https://invariel.ca/webauth/twitch_auth.html
// Client ID: arjb0z5kjqs974gbwblt8aryaugvmc

namespace Twitch_Channel_Points_Redemption_Timer
{
    public partial class RedemptionTimer : Form
    {
        internal BindingList<LocalRedemption> _redemptions = new BindingList<LocalRedemption>();
        private string outputFile;

        private ITwitchPubSub _twitchPubSub;
        private TwitchLib.Api.Helix.Helix _twitchAPI;

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

            outputFile = output.OutputFile;
            _redemptions = new BindingList<LocalRedemption>(output.Redemptions);

            InitializeComponent();

            _redemptions.AllowNew = true;
            _redemptions.AllowEdit = true;
            _redemptions.AllowRemove = true;
            dg_Redemptions.DataSource = _redemptions;
            dg_Redemptions.DataBindings.CollectionChanged += SaveRedemptions;
            dg_Redemptions.CellValidating += ValidateTimeSpan;

            UpdateSettingsFields();
            UpdateRedemptions();
        }

        private void UpdateSettingsFields()
        {
            txt_Username.Text = _twitchConnection.ChannelName;
            txt_UserId.Text = _twitchConnection.ChannelId;
            txt_OAuth.Text = _twitchConnection.OAuthToken;
            txt_OutputFileName.Text = outputFile;
        }

        private void UpdateRedemptions()
        {
            dg_Redemptions.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dg_Redemptions.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dg_Redemptions.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dg_Redemptions.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
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
                output.OutputFile = outputFile;
                output.Redemptions = _redemptions.ToList<LocalRedemption>();

                output.Redemptions.RemoveAll(r => string.IsNullOrEmpty(r.Name));

                string serializedRedemptions = JsonSerializer.Serialize(output, new JsonSerializerOptions()
                {
                    WriteIndented = true
                });

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
            LocalRedemption? redemption = _redemptions.FirstOrDefault(r => r.Name.Equals(e.RewardRedeemed.Redemption.Reward.Title, StringComparison.OrdinalIgnoreCase));

            if (redemption is not null)
            {

            }
        }
    }
}