namespace QiMata.CaptainPlanetFoundation.Dal
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("WaterTest")]
    public partial class WaterTest
    {
        public int WaterTestId { get; set; }

        public int WaterQualityMonitoringId { get; set; }

        [Required]
        [StringLength(50)]
        public string Test { get; set; }

        public virtual WaterQualityMonitoring WaterQualityMonitoring { get; set; }
    }
}
