namespace QiMata.CaptainPlanetFoundation.Dal
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EditableGarden")]
    public partial class EditableGarden
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int EditableGardenId { get; set; }

        public int SquareFeet { get; set; }

        [StringLength(50)]
        public string UseOfHarvest { get; set; }

        public virtual ProjectBase ProjectBase { get; set; }
    }
}
