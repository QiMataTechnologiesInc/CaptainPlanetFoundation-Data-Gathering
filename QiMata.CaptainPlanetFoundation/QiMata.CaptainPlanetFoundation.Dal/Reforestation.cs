namespace QiMata.CaptainPlanetFoundation.Dal
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Reforestation")]
    public partial class Reforestation
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Reforestation()
        {
            TreeSpecies = new HashSet<TreeSpecy>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ReforestationId { get; set; }

        public int NumberOfTreesPlanted { get; set; }

        public int? AreaOfTrees { get; set; }

        [StringLength(50)]
        public string AreaOfTreesUnits { get; set; }

        public virtual ProjectBase ProjectBase { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TreeSpecy> TreeSpecies { get; set; }
    }
}
