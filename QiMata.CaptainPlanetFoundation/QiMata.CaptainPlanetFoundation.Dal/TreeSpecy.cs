namespace QiMata.CaptainPlanetFoundation.Dal
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TreeSpecy
    {
        [Key]
        public int TreeSpeciesId { get; set; }

        public int ReforestationId { get; set; }

        [Required]
        [StringLength(250)]
        public string Species { get; set; }

        public virtual ProjectBase ProjectBase { get; set; }

        public virtual Reforestation Reforestation { get; set; }
    }
}
