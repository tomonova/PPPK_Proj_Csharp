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
    
    public partial class SERVISI
    {
        public int IDServisStavka { get; set; }
        public int ServisID { get; set; }
        public int StavkaID { get; set; }
    
        public virtual SERVIS_STAVKE SERVIS_STAVKE { get; set; }
        public virtual SERVISNA_KNJIGA SERVISNA_KNJIGA { get; set; }
        public override string ToString() => $"Stavka: {SERVIS_STAVKE.Naziv} ; Cijena: {SERVIS_STAVKE.Cijena}";
    }
}