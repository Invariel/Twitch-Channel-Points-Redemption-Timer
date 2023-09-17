using System.ComponentModel;
using System.Text.Json;
using System.Timers;
using Microsoft.Extensions.Configuration;
using NetCoreAudio;
using Twitch_Channel_Points_Redemption_Timer.Models;
using TwitchLib.Api.Helix;
using TwitchLib.Api.Helix.Models.ChannelPoints.GetCustomReward;
using TwitchLib.PubSub.Interfaces;

using LocalRedemption = Twitch_Channel_Points_Redemption_Timer.Models.Redemption;
using Timer = System.Timers.Timer;

// Webauth URL: https://invariel.ca/webauth/twitch_auth.html
// Client ID: arjb0z5kjqs974gbwblt8aryaugvmc

namespace Twitch_Channel_Points_Redemption_Timer
{
    public partial class RedemptionTimer : Form
    {
        private string _isConnected = "Connected";
        private string _isNotConnected = "Start Listening";

        private bool timersEnabled = true;
        private string _enableTimers = "Enable Timers";
        private string _disableTimers = "Pause Timers";

        private bool soundsEnabled = true;
        private string _enableSounds = "Unmute Sounds";
        private string _muteSounds = "Mute Sounds";
        private Timer _soundTimer;

        // Figure out how to play sound.  :|

        private ITwitchPubSub _twitchPubSub;
        private Helix _helix;

        // ([ "group": ({ { "name"; "duration" }, { "name"; "duration" }, ... }) ]);
        internal Dictionary<string, List<TimedRedemption>> _timers = new Dictionary<string, List<TimedRedemption>>(StringComparer.InvariantCultureIgnoreCase);
        private Timer _redemptionTimer;
        private TimeSpan _updateInterval = new TimeSpan(0, 0, 0, 0, 100);

        internal BindingList<LocalRedemption> _redemptions = new BindingList<LocalRedemption>();
        private string outputFilename;
        private FileStream outputFile;

        private TwitchConnection _twitchConnection;

        private bool _bindingRedemptions = false;

        private Player _player;
        private bool _finishedPlaying = true;
        private SemaphoreSlim _playingAudio = new SemaphoreSlim(1, 1);
        private List<string> _queuedSoundFiles = new List<string>();

        public RedemptionTimer(ITwitchPubSub pubsub, IConfiguration configuration)
        {
            _twitchConnection = new TwitchConnection();
            configuration.GetRequiredSection("Twitch").Bind(_twitchConnection);

            InitializeComponent();

            Output output = new Output();
            configuration.GetRequiredSection("Output").Bind(output);

            outputFilename = output.OutputFile;
            _redemptions = new BindingList<LocalRedemption>(output.Redemptions);

            _redemptions.AllowNew = true;
            _redemptions.AllowEdit = true;
            _redemptions.AllowRemove = true;
            _redemptions.ListChanged += SaveRedemptions;
            dg_Redemptions.DataSource = _redemptions;
            dg_Redemptions.CellValidating += ValidateTimeSpan;

            UpdateSettingsFields();
            UpdateRedemptions();

            InitializeHelix();

            _twitchPubSub = pubsub;

            _twitchPubSub.OnChannelPointsRewardRedeemed += _twitchPubSub_OnChannelPointsRewardRedeemed;
            _twitchPubSub.OnPubSubServiceConnected += _twitchPubSub_OnPubSubServiceConnected;
            _twitchPubSub.OnPubSubServiceError += _twitchPubSub_OnPubSubServiceError;

            txt_UserId.TextChanged += delegate { InitializeHelix(); };
            txt_OAuth.TextChanged += delegate { InitializeHelix(); };

            btn_OAuth.Click += GenerateOAuthToken;
            btn_RedemptionCreate.Click += CreateRedemption;
            btn_StartListening.Click += ConnectToTwitch;

            btn_EnableAll.Click += EnableAllRedemptions;
            btn_DisableAll.Click += DisableAllRedemptions;
            btn_MuteSounds.Click += MuteOrUnmuteSounds;
            btn_PauseTimers.Click += PauseOrUnpauseTimers;

            _redemptionTimer = new Timer();
            _redemptionTimer.Interval = _updateInterval.TotalMilliseconds;
            _redemptionTimer.Elapsed += UpdateTimes;
            _redemptionTimer.Start();

            _soundTimer = new Timer();
            _soundTimer.Interval = _updateInterval.TotalMilliseconds;
            _soundTimer.Elapsed += PlaySounds;
            _soundTimer.Start();

            _player = new Player();
            _player.PlaybackFinished += (s, e) => { _finishedPlaying = true; };

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
            dg_Redemptions.Columns["Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dg_Redemptions.Columns["Name"].FillWeight = 75;
            dg_Redemptions.Columns["Duration"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dg_Redemptions.Columns["Duration"].FillWeight = 30;
            dg_Redemptions.Columns["ActiveSoundEffect"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dg_Redemptions.Columns["ActiveSoundEffect"].FillWeight = 40;
            dg_Redemptions.Columns["ExpiredSoundEffect"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dg_Redemptions.Columns["ExpiredSoundEffect"].FillWeight = 40;
            dg_Redemptions.Columns["Group"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dg_Redemptions.Columns["Group"].FillWeight = 20;
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

        private void MuteOrUnmuteSounds(object? sender, EventArgs? e)
        {
            soundsEnabled = !soundsEnabled;

            btn_MuteSounds.Invoke((MethodInvoker)delegate
            {
                btn_MuteSounds.Text = soundsEnabled ? _muteSounds : _enableSounds;
            });
        }

        private void PauseOrUnpauseTimers(object? sender, EventArgs? e)
        {
            timersEnabled = !timersEnabled;

            btn_PauseTimers.Invoke((MethodInvoker)delegate
            {
                btn_PauseTimers.Text = timersEnabled ? _disableTimers : _enableTimers;
            });
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

            btn_StartListening.Invoke((MethodInvoker)delegate
            {
                btn_StartListening.Text = _isConnected;
                btn_StartListening.Enabled = false;
            });
        }

        private void _twitchPubSub_OnPubSubServiceError(object? sender, EventArgs? e)
        {
            MessageBox.Show($"Error in connecting to Twitch.{Environment.NewLine}{e}");

            btn_StartListening.Invoke((MethodInvoker)delegate
            {
                btn_StartListening.Text = _isNotConnected;
                btn_StartListening.Enabled = true;
            });
        }

        private async void _twitchPubSub_OnChannelPointsRewardRedeemed(object? sender, TwitchLib.PubSub.Events.OnChannelPointsRewardRedeemedArgs e)
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
                    _timers.Add(groupName, new List<TimedRedemption>() { new TimedRedemption { Name = key, Duration = redemption.Duration } });
                    QueueSoundFile(redemption.ActiveSoundEffect);
                }
            }
        }

        /// <summary></summary>
        /// <param name="redemption"></param>
        /// <returns>True if the redemption has time remaining, false otherwise.</returns>
        private bool UpdateRedemption(ref TimedRedemption redemption)
        {
            redemption.Duration = redemption.Duration.Subtract(_updateInterval);
            return redemption.Duration >= TimeSpan.Zero;
        }

        private async void UpdateGroup(string group)
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
                    string? soundFile = _redemptions.FirstOrDefault(r => r.Name == firstRedemption.Name)?.ExpiredSoundEffect ?? null;

                    QueueSoundFile(soundFile);
                    _timers[group].Remove(firstRedemption);

                    if (_timers[group].Any())
                    {
                        firstRedemption = _timers[group].First();
                        soundFile = _redemptions.FirstOrDefault(r => r.Name == firstRedemption.Name)?.ActiveSoundEffect ?? null;

                        await _playingAudio.WaitAsync();
                        QueueSoundFile(soundFile);
                    }
                }
            }
        }

        private void QueueSoundFile(string? soundFile)
        {
            if (soundFile is not null)
            {
                _queuedSoundFiles.Add(soundFile);
            }

            _queuedSoundFiles.RemoveAll(q => string.IsNullOrEmpty(q));
        }

        private void PlaySounds(object? sender, EventArgs e)
        {
            if (_finishedPlaying && _queuedSoundFiles.Any())
            {
                string? soundFile = _queuedSoundFiles.FirstOrDefault();
                _queuedSoundFiles.RemoveAt(0);

                if (soundFile is not null)
                {
                    var _ = PlaySoundEffect(soundFile);
                }
            }
        }

        private async Task PlaySoundEffect(string? soundFile)
        {
            if (soundsEnabled && !string.IsNullOrEmpty(soundFile) && File.Exists(soundFile))
            {
                try
                {
                    _finishedPlaying = false;
                    await _player.SetVolume((byte)numud_Volume.Value).ConfigureAwait(false);
                    await _player.Play(soundFile).ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Your sound file '{soundFile}' failed to play.  Reason: {ex.Message}");
                }
            }
        }

        private void UpdateTimes(object? sender, ElapsedEventArgs _)
        {
            if (!timersEnabled)
            {
                return;
            }

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

        #region Twitch Stuff
        private void GenerateOAuthToken(object? sender, EventArgs? e)
        {
            string uri = "https://id.twitch.tv/oauth2/authorize?client_id=" +
                         General.CLIENT_ID +
                         "&redirect_uri=" +
                         General.AUTH_URI +
                         "&response_type=token" +
                         "&scope=channel:read:redemptions%20channel:manage:redemptions" +
                         "&state=" +
                         General.GenerateStateString();

            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = uri,
                UseShellExecute = true
            });
        }

        private void InitializeHelix()
        {
            _helix = new TwitchLib.Api.Helix.Helix();
            _helix.Settings.ClientId = General.CLIENT_ID;
            _helix.Settings.AccessToken = txt_OAuth.Text ?? _twitchConnection.OAuthToken ?? "";
        }

        private void ValidateHelix()
        {
            ArgumentException.ThrowIfNullOrEmpty(_helix.Settings.ClientId, nameof(_helix.Settings.ClientId));
            ArgumentException.ThrowIfNullOrEmpty(_helix.Settings.AccessToken, nameof(_helix.Settings.AccessToken));
        }

        private async void ConnectToTwitch(object? sender, EventArgs? e)
        {
            try
            {
                ValidateHelix();

                var userIds = await _helix.Users.GetUsersAsync(logins: new List<string>() { _twitchConnection.ChannelName }, accessToken: _helix.Settings.AccessToken);

                txt_UserId.Invoke((MethodInvoker)delegate { txt_UserId.Text = userIds.Users[0].Id; });
                _twitchConnection.ChannelId = userIds.Users[0].Id;

                _twitchPubSub.ListenToChannelPoints(_twitchConnection.ChannelId);
                _twitchPubSub.Connect();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"There was a problem: {ex.Message}{Environment.NewLine}{ex.InnerException?.Message}");

                btn_StartListening.Text = _isNotConnected;
                btn_StartListening.Enabled = false;
            }
        }

        public async void CreateRedemption(object? sender, EventArgs? e)
        {
            try
            {
                string rewardName = txt_RedemptionName.Text;
                int rewardPoints = (int)numud_RedemptionPoints.Value;
                string rewardPrompt = txt_RedemptionPrompt.Text;
                bool rewardInputRequired = chk_RedemptionUserInputRequired.Checked;

                await _helix.ChannelPoints.CreateCustomRewardsAsync(
                    broadcasterId: txt_UserId.Text,
                    request: new TwitchLib.Api.Helix.Models.ChannelPoints.CreateCustomReward.CreateCustomRewardsRequest()
                    {
                        Title = rewardName,
                        Cost = rewardPoints,
                        IsUserInputRequired = rewardInputRequired,
                        Prompt = rewardInputRequired ? rewardPrompt : null,
                        IsEnabled = true,
                    });

                MessageBox.Show("Redemption created successfully.  Please access your Twitch dashboard to edit the redemption's description.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred trying to create the redemption: {ex.Message}");
            }
        }

        private async Task<GetCustomRewardsResponse> GetAllRedemptions()
            => await _helix.ChannelPoints.GetCustomRewardAsync(_helix.Settings.ClientId, null, true, _helix.Settings.AccessToken);

        private async void EnableAllRedemptions(object? sender, EventArgs? e)
        {
            var redeems = (await GetAllRedemptions()).Data;

            var validRedeems = redeems.Where(r => _redemptions.Any(redemption => redemption.Name.Equals(r.Title, StringComparison.InvariantCultureIgnoreCase)));

            foreach (var redeem in validRedeems)
            {
                await _helix.ChannelPoints.UpdateCustomRewardAsync(
                    broadcasterId: _helix.Settings.ClientId,
                    accessToken: _helix.Settings.AccessToken,
                    rewardId: redeem.Id,
                    request: new TwitchLib.Api.Helix.Models.ChannelPoints.UpdateCustomReward.UpdateCustomRewardRequest() { IsEnabled = true }
                );
            }
        }

        private async void DisableAllRedemptions(object? sender, EventArgs? e)
        {
            var redeems = (await GetAllRedemptions()).Data;

            var validRedeems = redeems.Where(r => _redemptions.Any(redemption => redemption.Name.Equals(r.Title, StringComparison.InvariantCultureIgnoreCase)));

            foreach (var redeem in validRedeems)
            {
                await _helix.ChannelPoints.UpdateCustomRewardAsync(
                    broadcasterId: _helix.Settings.ClientId,
                    accessToken: _helix.Settings.AccessToken,
                    rewardId: redeem.Id,
                    request: new TwitchLib.Api.Helix.Models.ChannelPoints.UpdateCustomReward.UpdateCustomRewardRequest() { IsEnabled = false }
                );
            }
        }
        #endregion
    }
}