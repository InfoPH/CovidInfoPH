using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidInfoPH.Models
{
    public class RegionDateInfo
    {
        public int Deaths { get; set; }
        public int Cases { get; set; }
        public int Recoveries { get; set; }

        public RegionDateInfo ShallowCopy()
        {
            return (RegionDateInfo) MemberwiseClone();
        }
    }
}
