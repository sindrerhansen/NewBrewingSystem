using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRH.NBS.Commen
{
    public class HeatingElement
    {
        public bool StateSetpoint { get; protected set; }
        public double AmbiantTemperature { get; set; }
        public bool State { get; protected set; }
        public double Effiefficiency { get; set; }


    }
}
