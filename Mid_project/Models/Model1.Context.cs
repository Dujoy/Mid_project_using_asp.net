﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Mid_project.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class MIDEntities : DbContext
    {
        public MIDEntities()
            : base("name=MIDEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<adv_details> adv_details { get; set; }
        public virtual DbSet<b_profile> b_profile { get; set; }
        public virtual DbSet<customer> customers { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<s_appartment_details> s_appartment_details { get; set; }
        public virtual DbSet<s_profile> s_profile { get; set; }
        public virtual DbSet<t_profile> t_profile { get; set; }
        public virtual DbSet<trans_details_sb> trans_details_sb { get; set; }
        public virtual DbSet<user_details> user_details { get; set; }
        public object Customers { get; internal set; }
    }
}