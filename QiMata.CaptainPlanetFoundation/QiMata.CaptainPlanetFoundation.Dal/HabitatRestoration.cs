namespace QiMata.CaptainPlanetFoundation.Dal
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HabitatRestoration")]
    public partial class HabitatRestoration
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HabitatRestoration()
        {
            TargetedSpecies = new HashSet<TargetedSpecy>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int HabitatRestorationId { get; set; }

        [Column(TypeName = "numeric")]
        public decimal SizeOfRestoration { get; set; }

        [Required]
        [StringLength(100)]
        public string UnitsOfRestoration { get; set; }

        [Required]
        [StringLength(10)]
        public string AddedOrRestored { get; set; }

        [Required]
        [StringLength(100)]
        public string RestorationType { get; set; }

        public int? TotalAreaRestored { get; set; }

        public virtual ProjectBase ProjectBase { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TargetedSpecy> TargetedSpecies { get; set; }
    }
}
