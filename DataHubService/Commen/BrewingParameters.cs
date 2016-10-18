using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace SRH.NBS.Commen
{
    public class BrewingParameters
    {
        public double HltStartTemperature { get; set; }
        public double MashInnTemperature { get; set; }
        public List<MashStage> MashStages { get; set; }
        public double SpargeTemperature { get; set; }
        public double SpargeVolume { get; set; }
        public int BoilTimeMinuts { get; set; }
    }
    
    public class MashStage
    {
        public int Minuts { get; set; }
        public double TemperatureSetPoint { get; set; }

    }
}
