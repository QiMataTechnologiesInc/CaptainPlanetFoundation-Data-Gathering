using System.Collections.Generic;

namespace QiMata.CaptainPlanetFoundation.Models
{
    public partial class WasteDiversion
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public WasteDiversion()
        {
            TypeOfWastes = new HashSet<TypeOfWaste>();
        } 
        public int WasteDiversionId { get; set; }
        
        public decimal AmountDiverted { get; set; }
        
        public string Units { get; set; }

        public virtual ProjectBase ProjectBase { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TypeOfWaste> TypeOfWastes { get; set; }
    }
}
