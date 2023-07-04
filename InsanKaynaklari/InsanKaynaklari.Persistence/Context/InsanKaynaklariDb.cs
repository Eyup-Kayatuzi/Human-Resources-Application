using InsanKaynaklari.Domain.Entities;
using InsanKaynaklari.Domain.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsanKaynaklari.Persistence.Context
{
    public class InsanKaynaklariDb : IdentityDbContext<AppIdentityUser>
    {
        public InsanKaynaklariDb(DbContextOptions<InsanKaynaklariDb> option) : base(option)
        {
            
        }

        // Dbsetler burada yazilacak
        public DbSet<PersonnelExpense> PersonnelExpenses { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            AddDummyRoles(builder);
            base.OnModelCreating(builder);
        }
        private static void AddDummyRoles(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppIdentityRole>().HasData(
                new AppIdentityRole()
                {
                    Name = "sirketyoneticisi",
                    NormalizedName = "SIRKETADMIN",
                    ConcurrencyStamp = "1",
                    Description = "Bu sirket yöneticisi roludur.",
                },
                new AppIdentityRole()
                {
                    Name = "siteyoneticisi",
                    NormalizedName = "SITEADMIN",
                    ConcurrencyStamp = "2",
                    Description = "Bu site yöneticisi roludur.",
                },
                new AppIdentityRole()
                {
                    Name = "personel",
                    NormalizedName = "PERSONEL",
                    ConcurrencyStamp = "10",
                    Description = "Bu personel roludur.",
                });
        }
    }
}
