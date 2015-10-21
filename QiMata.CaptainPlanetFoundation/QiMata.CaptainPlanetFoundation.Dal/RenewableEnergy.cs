namespace QiMata.CaptainPlanetFoundation.Dal
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RenewableEnergy")]
    public partial class RenewableEnergy
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int RenewableEnergyId { get; set; }

        [Required]
        [StringLength(100)]
        public string TypeOfEnergy { get; set; }

        public virtual ProjectBase ProjectBase { get; set; }
    }
}
