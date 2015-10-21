namespace QiMata.CaptainPlanetFoundation.Models
{
    public partial class TypesGrown
    {
        public int TypesGrownId { get; set; }

        public int AquaponicProjectId { get; set; }
        
        public string TypeGrown { get; set; }

        public virtual AquaponicProject AquaponicProject { get; set; }
    }
}
