using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitch_Channel_Points_Redemption_Timer.Models
{
    public class Redemption
    {
        public string Name { get; init; } = "";
        public TimeSpan Duration { get; init; } = TimeSpan.Zero;
        public string ActiveSoundEffect { get; init; } = "";
        public string ExpiredSoundEffect { get; init; } = "";
        public string Group { get; set; } = "";
        public bool UseMessage { get; set; } = false;
        public bool Enabled { get; set; } = false;
    }
}
