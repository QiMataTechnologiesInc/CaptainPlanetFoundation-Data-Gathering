namespace QiMata.CaptainPlanetFoundation.Dal
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("WasteDiversion")]
    public partial class WasteDiversion
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public WasteDiversion()
        {
            TypeOfWastes = new HashSet<TypeOfWaste>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int WasteDiversionId { get; set; }

        [Column(TypeName = "numeric")]
        public decimal AmountDiverted { get; set; }

        [Required]
        [StringLength(50)]
        public string Units { get; set; }

        public virtual ProjectBase ProjectBase { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TypeOfWaste> TypeOfWastes { get; set; }
    }
}
