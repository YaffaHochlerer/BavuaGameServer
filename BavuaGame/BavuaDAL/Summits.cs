//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BavuaDAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class Summits
    {
        public int summit_code { get; set; }
        public int summit_user_code { get; set; }
        public int summit_against_user_code { get; set; }
        public int summit_number_cards { get; set; }
        public System.DateTime summit_date { get; set; }
        public bool summit_isTimer { get; set; }
        public System.DateTime summit_duration { get; set; }
    
        public virtual Users Users { get; set; }
    }
}
