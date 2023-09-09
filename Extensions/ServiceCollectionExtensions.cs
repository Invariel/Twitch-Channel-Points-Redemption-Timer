using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitchLib.PubSub;
using TwitchLib.PubSub.Interfaces;

namespace Twitch_Channel_Points_Redemption_Timer.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void ConfigureServices (this IServiceCollection services)
        {
            services
                .AddSingleton<ITwitchPubSub, TwitchPubSub>()
                .AddScoped<RedemptionTimer>();
        }
    }
}
