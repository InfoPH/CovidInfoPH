using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidInfoPH.Models
{
    class ItemSource
    {
        public ObservableCollection<PhRegion> Regions { get; set; }

        public ItemSource(Dictionary<string, RegionInfo> valuePairs)
        {
            Regions = GetRegions(valuePairs);
        }

        public static ObservableCollection<PhRegion> GetRegions(Dictionary<string, RegionInfo> valuePairs)
        {
            ObservableCollection<PhRegion> regionsList = new ObservableCollection<PhRegion>();
            foreach (var item in valuePairs)
            {
                regionsList.Add(new PhRegion() { Cases = item.Value.Cases, Region = item.Key });
            }
            return regionsList;
        }
    }
}
