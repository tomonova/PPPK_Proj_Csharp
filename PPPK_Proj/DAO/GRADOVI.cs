//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PPPK_Proj.DAO
{
    using System;
    using System.Collections.Generic;
    
    public partial class GRADOVI
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GRADOVI()
        {
            this.PUTNI_NALOZI = new HashSet<PUTNI_NALOZI>();
            this.PUTNI_NALOZI1 = new HashSet<PUTNI_NALOZI>();
        }
    
        public int IDGrad { get; set; }
        public string Ime { get; set; }
        public decimal Latitutde { get; set; }
        public decimal Longitude { get; set; }
        public int DrzavaID { get; set; }
    
        public virtual DRZAVE DRZAVE { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PUTNI_NALOZI> PUTNI_NALOZI { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PUTNI_NALOZI> PUTNI_NALOZI1 { get; set; }
    }
}
