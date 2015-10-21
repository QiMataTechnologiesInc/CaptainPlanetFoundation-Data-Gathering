namespace QiMata.CaptainPlanetFoundation.Models
{
    public partial class RenewableEnergy
    {
        public int RenewableEnergyId { get; set; }
        
        public string TypeOfEnergy { get; set; }

        public virtual ProjectBase ProjectBase { get; set; }
    }
}
