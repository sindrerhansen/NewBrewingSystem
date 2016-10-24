using SRH.NBS.Commen;

namespace SRH.NBS.DataCollectorService
{
    class Collector
    {

        static void Main(string[] args)
        {
            var realtimeHub = new SignalrClient("192.168.3.80");
            var udpCollector = new UdpCollector(realtimeHub);
            

            udpCollector.Start();
        }
        
    }
}
