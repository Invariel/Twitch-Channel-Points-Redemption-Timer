using Microsoft.Extensions.Configuration;
using System.Security.Cryptography.X509Certificates;
using TwitchLib.PubSub.Interfaces;
using TwitchLib.PubSub.Models.Responses.Messages.Redemption;

using LocalRedemption = Twitch_Channel_Points_Redemption_Timer.Models.Redemption;

namespace Twitch_Channel_Points_Redemption_Timer
{
    public partial class RedemptionTimer : Form
    {
        private List<LocalRedemption> _redemptions = new List<LocalRedemption>();
        private string outputFile;

        private ITwitchPubSub _twitchPubSub;

        public RedemptionTimer(ITwitchPubSub pubsub, IConfiguration configuration)
        {
            _twitchPubSub = pubsub;

            _twitchPubSub.OnChannelPointsRewardRedeemed += _twitchPubSub_OnChannelPointsRewardRedeemed;
            _twitchPubSub.Connect();

            Output output = new Output();
            configuration.GetRequiredSection("Output").Bind(output);

            InitializeComponent();
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