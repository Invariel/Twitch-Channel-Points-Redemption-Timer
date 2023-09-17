using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitch_Channel_Points_Redemption_Timer
{
    internal static class General
    {
        internal const string CLIENT_ID = "arjb0z5kjqs974gbwblt8aryaugvmc";
        internal const string AUTH_URI = @"https://invariel.ca/webauth/twitch_auth.html";

        private const string STATE_CHARACTERS = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890";

        public static string GenerateStateString()
        {
            Random random = new Random();

            string stateString = "TADA_";

            for (int i = 0; i < 40; ++i)
            {
                stateString += STATE_CHARACTERS[random.Next(STATE_CHARACTERS.Length)];
            }

            return stateString;
        }
    }
}
