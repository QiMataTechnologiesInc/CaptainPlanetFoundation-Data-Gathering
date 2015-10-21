namespace QiMata.CaptainPlanetFoundation.Dal
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TargetedSpecy
    {
        [Key]
        public int TargetedSpeciesId { get; set; }

        public int HabitatRestorationId { get; set; }

        [Required]
        [StringLength(100)]
        public string SpeciesName { get; set; }

        public virtual HabitatRestoration HabitatRestoration { get; set; }
    }
}
