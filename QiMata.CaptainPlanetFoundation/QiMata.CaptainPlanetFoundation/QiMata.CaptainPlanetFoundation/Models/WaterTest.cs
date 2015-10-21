namespace QiMata.CaptainPlanetFoundation.Models
{
    public partial class WaterTest
    {
        public int WaterTestId { get; set; }
        
        public int WaterQualityMonitoringId { get; set; }
        
        public string Test { get; set; }

        public virtual WaterQualityMonitoring WaterQualityMonitoring { get; set; }
    }
}
