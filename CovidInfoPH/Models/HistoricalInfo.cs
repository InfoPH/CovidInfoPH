using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidInfoPH.Models
{
    public class HistoricalInfo
    {
        public int Cases { get; set; }
        public int Deaths { get; set; }
        public int Recoveries { get; set; }
        public int Admitted { get; set; }
    }
}