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
    
    public partial class Cards_in_cash
    {
        public int cards_in_cash_code { get; set; }
        public int cards_in_cash_cash_code { get; set; }
        public int cards_in_cash_card_code { get; set; }
        public bool cards_in_kupa_isWin { get; set; }
        public bool cards_in_kupa_isOpened { get; set; }
    
        public virtual Cards Cards { get; set; }
        public virtual Cashes Cashes { get; set; }
    }
}
