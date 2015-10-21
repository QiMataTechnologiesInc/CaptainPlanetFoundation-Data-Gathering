namespace QiMata.CaptainPlanetFoundation.Models
{
    public partial class TreeSpecy
    {
        public int TreeSpeciesId { get; set; }

        public int ReforestationId { get; set; }
        
        public string Species { get; set; }

        public virtual Reforestation Reforestation { get; set; }
    }
}
