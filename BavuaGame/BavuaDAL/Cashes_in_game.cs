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
    
    public partial class Cashes_in_game
    {
        public int cashes_in_game_code { get; set; }
        public int cashes_in_game_game_code { get; set; }
        public int cashes_in_game_cash_code { get; set; }
    
        public virtual Cashes Cashes { get; set; }
        public virtual Save_games Save_games { get; set; }
    }
}
