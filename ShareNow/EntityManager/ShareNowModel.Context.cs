﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EntityManager
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ShareNowDBEntities : DbContext
    {
        public ShareNowDBEntities()
            : base("name=ShareNowDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<Share> Shares { get; set; }
        public virtual DbSet<User> Users { get; set; }
    }
}
