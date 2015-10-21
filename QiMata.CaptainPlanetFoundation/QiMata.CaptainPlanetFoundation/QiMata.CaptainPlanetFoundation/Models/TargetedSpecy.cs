namespace QiMata.CaptainPlanetFoundation.Models
{
    public partial class TargetedSpecy
    {
        public int TargetedSpeciesId { get; set; }

        public int HabitatRestorationId { get; set; }
        
        public string SpeciesName { get; set; }

        public virtual HabitatRestoration HabitatRestoration { get; set; }
    }
}
