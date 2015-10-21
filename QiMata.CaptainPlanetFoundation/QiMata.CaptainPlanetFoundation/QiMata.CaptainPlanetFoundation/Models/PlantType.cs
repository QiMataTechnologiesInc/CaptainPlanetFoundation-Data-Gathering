namespace QiMata.CaptainPlanetFoundation.Models
{
    public partial class PlantType
    {
        public int PlantTypeId { get; set; }

        public int PollinatorGardenId { get; set; }
        
        public string Type { get; set; }

        public virtual PollinatorGarden PollinatorGarden { get; set; }
    }
}
