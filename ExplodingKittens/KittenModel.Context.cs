﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ExplodingKittens
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class KittensCardGameEntities : DbContext
    {
        public KittensCardGameEntities()
            : base("name=KittensCardGameEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Card> Cards { get; set; }
        public virtual DbSet<Game> Games { get; set; }
        public virtual DbSet<Hand> Hands { get; set; }
        public virtual DbSet<Player> Players { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
    }
}
