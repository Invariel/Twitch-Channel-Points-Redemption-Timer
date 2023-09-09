using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Twitch_Channel_Points_Redemption_Timer.Extensions;

namespace Twitch_Channel_Points_Redemption_Timer
{
    internal static class Program
    {
        public static IServiceProvider ServiceProvider { get; private set; }
        private static IConfiguration Configuration { get; set; }

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddJsonFile("connection.json")
                .Build();

            var services = new ServiceCollection();
            services.ConfigureServices();
            services.AddSingleton<IConfiguration>(configuration);

            var serviceProvider = services.BuildServiceProvider();

            Application.Run(serviceProvider.GetRequiredService<RedemptionTimer>());
        }
    }
}