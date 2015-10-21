namespace QiMata.CaptainPlanetFoundation.Dal
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PollinatorGarden")]
    public partial class PollinatorGarden
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PollinatorGarden()
        {
            PlantTypes = new HashSet<PlantType>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PollinatorGardenId { get; set; }

        public int GardenSize { get; set; }

        [Required]
        [StringLength(100)]
        public string GardentLocation { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PlantType> PlantTypes { get; set; }

        public virtual ProjectBase ProjectBase { get; set; }
    }
}
