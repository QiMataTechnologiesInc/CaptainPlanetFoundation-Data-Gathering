namespace QiMata.CaptainPlanetFoundation.Dal
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AquaponicProject")]
    public partial class AquaponicProject
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AquaponicProject()
        {
            TypesGrowns = new HashSet<TypesGrown>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AquaponicProjectId { get; set; }

        [Required]
        [StringLength(50)]
        public string Type { get; set; }

        public int? SizeOfHarvest { get; set; }

        public bool Harvested { get; set; }

        [StringLength(50)]
        public string UseOfHarvest { get; set; }

        public virtual ProjectBase ProjectBase { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TypesGrown> TypesGrowns { get; set; }
    }
}
