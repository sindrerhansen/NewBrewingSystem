using SRH.NBS.Commen;

namespace SRH.NBS.DataCollectorService
{
    class Collector
    {

        static void Main(string[] args)
        {
            var udpCollector = new UdpCollector();
            var realtimeHub = new SignalrClient("192.168.3.80");

            udpCollector.Start(realtimeHub);
        }
        
    }
}
