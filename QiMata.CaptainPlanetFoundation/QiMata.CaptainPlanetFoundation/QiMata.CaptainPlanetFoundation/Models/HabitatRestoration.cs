using System.Collections.Generic;

namespace QiMata.CaptainPlanetFoundation.Models
{
    public partial class HabitatRestoration
    {
        public HabitatRestoration()
        {
            TargetedSpecies = new HashSet<TargetedSpecy>();
        }

        public int HabitatRestorationId { get; set; }
        
        public decimal SizeOfRestoration { get; set; }
        
        public string UnitsOfRestoration { get; set; }
        
        public string AddedOrRestored { get; set; }
        
        public string RestorationType { get; set; }

        public int? TotalAreaRestored { get; set; }

        public ProjectBase ProjectBase { get; set; }
        
        public ICollection<TargetedSpecy> TargetedSpecies { get; set; }
    }
}
