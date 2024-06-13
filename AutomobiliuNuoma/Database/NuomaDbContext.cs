using AutomobiliuNuoma.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomobiliuNuoma.Database
{
    public class NuomaDbContext: DbContext
    {
        public DbSet<Klientas> Klientai {  get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-8V5PSN2;Database=AutomobiliuNuoma;Integrated Security=True;Trusted_Connection=true;TrustServerCertificate=true;");
        }
    }
}
