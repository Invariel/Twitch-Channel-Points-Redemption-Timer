using Microsoft.Extensions.Configuration;
using System.Security.Cryptography.X509Certificates;
using Twitch_Channel_Points_Redemption_Timer.Models;
using TwitchLib.Api.Helix.Models;
using TwitchLib.PubSub.Interfaces;
using TwitchLib.PubSub.Models.Responses.Messages.Redemption;

using LocalRedemption = Twitch_Channel_Points_Redemption_Timer.Models.Redemption;

// Webauth URL: https://invariel.ca/webauth/twitch_auth.html
// Client ID: arjb0z5kjqs974gbwblt8aryaugvmc

namespace Twitch_Channel_Points_Redemption_Timer
{
    public partial class RedemptionTimer : Form
    {
        private List<LocalRedemption> _redemptions = new List<LocalRedemption>();
        private string outputFile;

        private ITwitchPubSub _twitchPubSub;
        private TwitchLib.Api.Helix.Helix _twitchAPI;

        private TwitchConnection _twitchConnection;

        public RedemptionTimer(ITwitchPubSub pubsub, IConfiguration configuration)
        {
            _twitchConnection = new TwitchConnection();
            configuration.GetRequiredSection("Twitch").Bind(_twitchConnection);

            _twitchAPI = new TwitchLib.Api.Helix.Helix();
            _twitchAPI.Settings.ClientId = "hw23lau0o8duwhk5h3wgpal4mbznyl";
            _twitchAPI.Settings.AccessToken = _twitchConnection.OauthToken;
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
            _redemptions = output.Redemptions;

            InitializeComponent();
        }

        private void _twitchPubSub_OnPubSubServiceConnected(object? sender, EventArgs? e)
        {
            Console.WriteLine("Connected to Twitch PubSub.");
            _twitchPubSub.SendTopics(_twitchConnection.OauthToken);
        }

        private void _twitchPubSub_OnPubSubServiceError(object? sender, EventArgs? e)
        {
            Console.WriteLine("Error in connecting to Twitch.  Inspect 'e'.");
        }

        private void _twitchPubSub_OnChannelPointsRewardRedeemed(object? sender, TwitchLib.PubSub.Events.OnChannelPointsRewardRedeemedArgs? e)
        {
            LocalRedemption? redemption = _redemptions.FirstOrDefault(r => r.Name.Equals(e.RewardRedeemed.Redemption.Reward.Title, StringComparison.OrdinalIgnoreCase));

            if (redemption is not null)
            {
                Console.WriteLine(redemption.Name);
            }
        }
    }
}