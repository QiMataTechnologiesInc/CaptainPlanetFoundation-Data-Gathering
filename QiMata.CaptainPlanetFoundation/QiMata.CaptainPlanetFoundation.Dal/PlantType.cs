namespace QiMata.CaptainPlanetFoundation.Dal
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PlantType")]
    public partial class PlantType
    {
        public int PlantTypeId { get; set; }

        public int PollinatorGardenId { get; set; }

        [Required]
        [StringLength(100)]
        public string Type { get; set; }

        public virtual PollinatorGarden PollinatorGarden { get; set; }
    }
}
