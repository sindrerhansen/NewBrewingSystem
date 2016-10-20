using SRH.NBS.Commen;

namespace SRH.NBS.DataCollector
{
    class Collector
    {

        static void Main(string[] args)
        {
            var udpCollector = new UdpCollector();
            var realtimeHub = new SignalrClient("192.168.3.125");

            udpCollector.Start(realtimeHub);
        }
        
    }
}
