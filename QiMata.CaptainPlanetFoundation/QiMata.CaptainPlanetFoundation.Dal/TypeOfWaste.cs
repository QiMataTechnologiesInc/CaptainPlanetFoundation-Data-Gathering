namespace QiMata.CaptainPlanetFoundation.Dal
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TypeOfWaste")]
    public partial class TypeOfWaste
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TypeOfWasteId { get; set; }

        public int WasteDiversionId { get; set; }

        [Column("TypeOfWaste")]
        [Required]
        [StringLength(100)]
        public string TypeOfWaste1 { get; set; }

        public virtual WasteDiversion WasteDiversion { get; set; }
    }
}
