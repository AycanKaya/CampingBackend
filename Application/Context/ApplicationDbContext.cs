using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Application.Context
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
      : base(options)
        {
        }
      
        public DbSet<VacationSpot> Vacations { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<Campsite> Campsites { get; set; }
        public DbSet<Order> Orders { get; set; }
        public  DbSet<Payment> Payments { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<HolidayDestination> Holidays { get; set; }
        public DbSet<Link> Links { get; set; }
        

        public async Task<int> SaveChanges()
        {
           
            return await base.SaveChangesAsync();
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //   modelBuilder.Entity<Customer>().HasKey(c => c.Id);
            //   base.OnModelCreating(modelBuilder);

            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<VacationSpot>(entity =>
            {
                entity.HasKey(c => c.Id);
                entity.ToTable(name: "VacationSpot");

            });
            modelBuilder.Entity<Bill>(entity =>
            {
                entity.HasKey(c => c.Id);
                entity.ToTable(name: "Bill");

            });
            modelBuilder.Entity<Card>(entity =>
            {
                entity.HasKey(c => c.CardNo);
                entity.ToTable(name: "Card");

            });
            modelBuilder.Entity<Campsite>(entity =>
            {
                entity.HasKey(c => c.VacationSpotID);
                entity.ToTable(name: "Campsite");

            });
            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(c => c.Id);
                entity.ToTable(name: "Order");

            });
            modelBuilder.Entity<Payment>(entity =>
            {
                entity.HasKey(c => c.Id);
                entity.ToTable(name: "Payment");
            });
            modelBuilder.Entity<HolidayDestination>(entity =>
            { 
                entity.HasKey(c => c.Id);
                entity.ToTable(name: "HolidayDestination");

            });
            modelBuilder.Entity<Comment>(entity =>
            {
                entity.HasKey(c=> c.Id);
                entity.ToTable(name: "Comment");
            });

            modelBuilder.Entity<Link>(entity =>
            {
                entity.HasKey(c => c.Id);
                entity.ToTable(name: "Link");
            });
        }
    }
}
