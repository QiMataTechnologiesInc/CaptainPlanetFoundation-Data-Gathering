using System.Collections.Generic;

namespace QiMata.CaptainPlanetFoundation.Models
{
    public partial class PollinatorGarden
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PollinatorGarden()
        {
            PlantTypes = new HashSet<PlantType>();
        }
        
        public int PollinatorGardenId { get; set; }

        public int GardenSize { get; set; }
        
        public string GardentLocation { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PlantType> PlantTypes { get; set; }

        public virtual ProjectBase ProjectBase { get; set; }
    }
}
