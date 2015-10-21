using System;
using System.Collections.Generic;

namespace QiMata.CaptainPlanetFoundation.Models
{
    public partial class ProjectBase
    {
        public int ProjectBaseId { get; set; }

        public int NumberOfParticipants { get; set; }

        public string ProjectName { get; set; }
        
        public string ClassName { get; set; }
        
        public string DataReportedLocation { get; set; }

        public DateTimeOffset DateReported { get; set; }

        public string Description { get; set; }

        public byte[] Image { get; set; }

        public AquaponicProject AquaponicProject { get; set; }

        public EditableGarden EditableGarden { get; set; }

        public HabitatRestoration HabitatRestoration { get; set; }

        public PollinatorGarden PollinatorGarden { get; set; }

        public Reforestation Reforestation { get; set; }

        public RenewableEnergy RenewableEnergy { get; set; }

        public WasteDiversion WasteDiversion { get; set; }

        public WaterQualityMonitoring WaterQualityMonitoring { get; set; }
    }
}
