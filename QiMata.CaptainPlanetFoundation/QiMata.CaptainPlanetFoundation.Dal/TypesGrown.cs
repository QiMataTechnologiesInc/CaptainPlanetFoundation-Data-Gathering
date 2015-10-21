namespace QiMata.CaptainPlanetFoundation.Dal
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TypesGrown")]
    public partial class TypesGrown
    {
        public int TypesGrownId { get; set; }

        public int AquaponicProjectId { get; set; }

        [Required]
        [StringLength(100)]
        public string TypeGrown { get; set; }

        public virtual AquaponicProject AquaponicProject { get; set; }
    }
}
