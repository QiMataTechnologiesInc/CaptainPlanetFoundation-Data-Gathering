using System.Collections.Generic;

namespace QiMata.CaptainPlanetFoundation.Models
{
    public partial class AquaponicProject
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AquaponicProject()
        {
            TypesGrowns = new HashSet<TypesGrown>();
        }
        
        public int AquaponicProjectId { get; set; }
        
        public string Type { get; set; }

        public int? SizeOfHarvest { get; set; }

        public bool Harvested { get; set; }

        public string UseOfHarvest { get; set; }

        public virtual ProjectBase ProjectBase { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TypesGrown> TypesGrowns { get; set; }
    }
}
