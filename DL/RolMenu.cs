//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DL
{
    using System;
    using System.Collections.Generic;
    
    public partial class RolMenu
    {
        public int IdRolMenu { get; set; }
        public Nullable<int> IdMenu { get; set; }
        public Nullable<int> IdRol { get; set; }
    
        public virtual Menu Menu { get; set; }
        public virtual Rol Rol { get; set; }
    }
}
