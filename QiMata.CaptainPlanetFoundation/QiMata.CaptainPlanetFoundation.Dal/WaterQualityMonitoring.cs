namespace QiMata.CaptainPlanetFoundation.Dal
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("WaterQualityMonitoring")]
    public partial class WaterQualityMonitoring
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public WaterQualityMonitoring()
        {
            WaterTests = new HashSet<WaterTest>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int WaterQualityMonitoringId { get; set; }

        [Required]
        [StringLength(250)]
        public string FrequencyOfTest { get; set; }

        public virtual ProjectBase ProjectBase { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WaterTest> WaterTests { get; set; }
    }
}
