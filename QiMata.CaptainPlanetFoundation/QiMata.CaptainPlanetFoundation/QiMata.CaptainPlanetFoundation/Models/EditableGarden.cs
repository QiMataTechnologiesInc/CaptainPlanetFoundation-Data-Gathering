namespace QiMata.CaptainPlanetFoundation.Models
{
    public partial class EditableGarden
    {
        public int EditableGardenId { get; set; }

        public int SquareFeet { get; set; }
        
        public string UseOfHarvest { get; set; }

        public virtual ProjectBase ProjectBase { get; set; }
    }
}
