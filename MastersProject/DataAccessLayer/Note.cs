//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MastersProject.Core.DataAccessLayer
{
    using System;
    using System.Collections.Generic;
    
    public partial class Note
    {
        public long Id { get; set; }
        public string RelatedTo { get; set; }
        public string Message { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime DateCreated { get; set; }
    }
}
