using Common.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRest.Repository
{
    public class BankDbContext:DbContext
    {
        public BankDbContext(DbContextOptions options):base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClientConsultant>().HasKey(sc => new { sc.ClientId, sc.ConsultantId });
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Consultant> Consultants { get; set; }
        public DbSet<ClientConsultant> ClientConsultants { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<Office> Offices { get; set; }
        public DbSet<Record> Records { get; set; }

    }
}
