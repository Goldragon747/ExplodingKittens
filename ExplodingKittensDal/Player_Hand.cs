//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ExplodingKittensDAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class Player_Hand
    {
        public int PlayerID { get; set; }
        public int CardID { get; set; }
    
        public virtual Player Player { get; set; }
    }
}