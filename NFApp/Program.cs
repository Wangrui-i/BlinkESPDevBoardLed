using nanoFramework.DependencyInjection;
using nanoFramework.Hosting;
using NFApp.Services;

namespace NFApp
{
    public class Program
    {
        public static void Main()
        {
            // ����WiFi
            HardwareService.ConnectWifi();

            IHost host = Host.CreateDefaultBuilder()
                .ConfigureServices(services =>
                {
                    // Ӳ���豸
                    services.AddSingleton(typeof(HardwareService));

                    // ����LED��˸
                    services.AddHostedService(typeof(LEDBlinkService));

                    // �����㲥
                    services.AddHostedService(typeof(BLEBroadcastService));
                })
                .Build();

            host.Run();
        }
    }
}