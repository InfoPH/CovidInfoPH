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

        public ItemSource(Dictionary<string, Dictionary<DateTime, RegionDateInfo>> valuePairs)
        {
            Regions = GetRegions(valuePairs);
        }

        public static ObservableCollection<PhRegion> GetRegions(
            Dictionary<string, Dictionary<DateTime, RegionDateInfo>> valuePairs)
        {
            ObservableCollection<PhRegion> regionsList = new ObservableCollection<PhRegion>();
            foreach (var item in valuePairs)
            {
                regionsList.Add(new PhRegion() { Cases = item.Value.Values.Sum(c => c.Cases), Region = item.Key });
            }
            return regionsList;
        }
    }
}
