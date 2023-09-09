using Twitch_Channel_Points_Redemption_Timer.Models;
namespace Twitch_Channel_Points_Redemption_Timer
{
    public partial class RedemptionTimer
    {
        private class Output
        {
            public string OutputFile { get; set; } = "redemptions.txt";

            public List<Redemption> Redemptions { get; set; } = new List<Redemption>();
        }
    }
}