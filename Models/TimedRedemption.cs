using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitch_Channel_Points_Redemption_Timer.Models
{
    public class TimedRedemption
    {
        public string Name { get; set; } = "";
        public TimeSpan Duration { get; set; } = TimeSpan.Zero;
    }
}
