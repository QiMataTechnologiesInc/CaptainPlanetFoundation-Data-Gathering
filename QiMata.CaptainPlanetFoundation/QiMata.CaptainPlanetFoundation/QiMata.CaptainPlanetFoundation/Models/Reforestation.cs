using System.Collections.Generic;

namespace QiMata.CaptainPlanetFoundation.Models
{
    public partial class Reforestation
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Reforestation()
        {
            TreeSpecies = new HashSet<TreeSpecy>();
        }
        public int ReforestationId { get; set; }

        public int NumberOfTreesPlanted { get; set; }

        public int? AreaOfTrees { get; set; }
        public string AreaOfTreesUnits { get; set; }

        public virtual ProjectBase ProjectBase { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TreeSpecy> TreeSpecies { get; set; }
    }
}
