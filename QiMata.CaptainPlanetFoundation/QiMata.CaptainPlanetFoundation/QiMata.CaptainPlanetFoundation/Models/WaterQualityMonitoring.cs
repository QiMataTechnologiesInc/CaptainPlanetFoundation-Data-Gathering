using System.Collections.Generic;

namespace QiMata.CaptainPlanetFoundation.Models
{
    public partial class WaterQualityMonitoring
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public WaterQualityMonitoring()
        {
            WaterTests = new HashSet<WaterTest>();
        }
        public int WaterQualityMonitoringId { get; set; }
        public string FrequencyOfTest { get; set; }

        public virtual ProjectBase ProjectBase { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WaterTest> WaterTests { get; set; }
    }
}
