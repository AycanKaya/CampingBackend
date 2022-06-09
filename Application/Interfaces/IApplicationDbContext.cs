
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IApplicationDbContext
    {
        
        DbSet<VacationSpot> Vacations { get; set; }
        DbSet<Bill> Bills { get; set; }
        DbSet<Card> Cards { get; set; }
        DbSet<Campsite> Campsites { get; set; }
        DbSet<Order> Orders { get; set; }
        DbSet<Payment> Payments { get; set; }
        DbSet<Link> Links { get; set; }

        Task<int> SaveChanges();
       
    }
}
