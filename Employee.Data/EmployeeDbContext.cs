using Employe.Core.BundleEmployee.Models;
using Employee.Data.Commands.Mapping;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Data.Commands
{
    public class EmployeeDbContext : DbContext
    {
        public DbSet<Employees> Employees { get; set; }

        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options):base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new EmployeeMapping().Configure(modelBuilder.Entity<Employees>());
        }
    }
}
