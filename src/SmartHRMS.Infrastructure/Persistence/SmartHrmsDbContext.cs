using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SmartHRMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHRMS.Infrastructure.Persistence
{
    public class SmartHrmsDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>,Guid>
    {
        public SmartHrmsDbContext(DbContextOptions<SmartHrmsDbContext> options):base(options)
        {
            
        }

        public DbSet<Employee> Employees => Set<Employee>();
        public DbSet<Company> Companies => Set<Company>();
        public DbSet<Department> Departments => Set<Department>();
        public DbSet<Designation> Designations => Set<Designation>();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Company>(entity =>
            {
                entity.HasKey(x => x.Id);

                entity.Property(x => x.CompanyCode)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(x => x.CompanyName)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(x => x.Email)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(x => x.PhoneNumber)
                    .HasMaxLength(20);

                entity.Property(x => x.Address)
                    .HasMaxLength(500);

                entity.Property(x => x.Country)
                    .HasMaxLength(100);

                entity.Property(x => x.State)
                    .HasMaxLength(100);

                entity.Property(x => x.City)
                    .HasMaxLength(100);

                entity.Property(x => x.PostalCode)
                    .HasMaxLength(20);
            });

            builder.Entity<ApplicationUser>(entity =>
            {
                entity.Property(x => x.FirstName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(x => x.LastName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(x => x.Company)
                    .WithMany()
                    .HasForeignKey(x => x.CompanyId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
