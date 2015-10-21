namespace QiMata.CaptainPlanetFoundation.Models
{
    public partial class TypeOfWaste
    {
        public int TypeOfWasteId { get; set; }

        public int WasteDiversionId { get; set; }
        
        public string TypeOfWaste1 { get; set; }

        public virtual WasteDiversion WasteDiversion { get; set; }
    }
}
