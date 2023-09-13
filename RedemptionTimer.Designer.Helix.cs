using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitchLib.Api.Helix.Models.ChannelPoints.GetCustomReward;

namespace Twitch_Channel_Points_Redemption_Timer
{
    public partial class RedemptionTimer : Form
    {
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
    }
}