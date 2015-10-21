namespace QiMata.CaptainPlanetFoundation.Dal
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProjectBase")]
    public partial class ProjectBase
    {
        public int ProjectBaseId { get; set; }

        public int NumberOfParticipants { get; set; }

        [Required]
        [StringLength(100)]
        public string ProjectName { get; set; }

        [StringLength(100)]
        public string ClassName { get; set; }

        [Required]
        public string DataReportedLocation { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime DateReported { get; set; }

        public string Description { get; set; }

        public byte[] Image { get; set; }

        public AquaponicProject AquaponicProject { get; set; }

        public EditableGarden EditableGarden { get; set; }

        public HabitatRestoration HabitatRestoration { get; set; }

        public PollinatorGarden PollinatorGarden { get; set; }

        public Reforestation Reforestation { get; set; }

        public RenewableEnergy RenewableEnergy { get; set; }

        public TreeSpecy TreeSpecy { get; set; }

        public WasteDiversion WasteDiversion { get; set; }

        public WaterQualityMonitoring WaterQualityMonitoring { get; set; }
    }
}
