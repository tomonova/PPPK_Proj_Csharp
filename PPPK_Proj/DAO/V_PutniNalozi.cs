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
    
    public partial class V_PutniNalozi
    {
        public int IDNalog { get; set; }
        public Nullable<System.DateTime> OtvaranjeNaloga { get; set; }
        public Nullable<System.DateTime> ZatvaranjeNaloga { get; set; }
        public string Vozac { get; set; }
        public string Vozilo { get; set; }
        public string MjestoStart { get; set; }
        public string MjestoCilj { get; set; }
        public Nullable<int> StatusNaloga { get; set; }
    }
}