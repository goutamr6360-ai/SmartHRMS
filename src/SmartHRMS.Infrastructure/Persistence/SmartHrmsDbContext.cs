using Microsoft.EntityFrameworkCore;
using SmartHRMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHRMS.Infrastructure.Persistence
{
    public class SmartHrmsDbContext : DbContext
    {
        public SmartHrmsDbContext(DbContextOptions<SmartHrmsDbContext> options):base(options)
        {
            
        }

        public DbSet<Employee> Employees => Set<Employee>();
        public DbSet<Company> Companies => Set<Company>();
        public DbSet<Department> Departments => Set<Department>();
        public DbSet<Designation> Designations => Set<Designation>();
    }
}
