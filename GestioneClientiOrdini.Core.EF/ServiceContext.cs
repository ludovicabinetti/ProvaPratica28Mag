using System;
using System.Collections.Generic;
using System.Text;
using GestioneClientiOrdini.Core.EF.Configurations;
using GestioneClientiOrdini.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace GestioneClientiOrdini.Core.EF
{
    public class ServiceContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }  // in SQL server: tabella Customers
        public DbSet<Order> Orders { get; set; }        // in SQL server: tabella Orders

        #region Ctors
        public ServiceContext() : base() { } // costruttore di default

        public ServiceContext(DbContextOptions<ServiceContext> options) : base(options) { } // costruttore parametrico utile quando si usa Asp Net Core

        #endregion

        // metodo per configurare il Context nel caso in cui non si usi Asp Net Core
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                // metodo brutale di inserimento di una connection string
                string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=GestioneClientiOrdini-db;
                                            Integrated Security=True;Connect Timeout=30;Encrypt=False;
                                            TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

                options.UseSqlServer(connectionString);
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Customer>(new CustomerConfiguration());
            modelBuilder.ApplyConfiguration<Order>(new OrderConfiguration());
        }
    }
}
