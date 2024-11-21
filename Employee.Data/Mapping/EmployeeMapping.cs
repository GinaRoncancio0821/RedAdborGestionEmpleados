using Employe.Core.BundleEmployee.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Data.Commands.Mapping
{
    public class EmployeeMapping
    {
        public void Configure(EntityTypeBuilder<Employees> builder)
        {
            builder.HasKey(e => e.EmployeeId);

            builder
            .Property(e => e.CompanyId)
            .IsRequired();

            builder
           .Property(e => e.Email)
           .IsRequired();

            builder
           .Property(e => e.Password)
           .IsRequired();

            builder
           .Property(e => e.PortalId)
           .IsRequired();

            builder
           .Property(e => e.RoleId)
           .IsRequired();

            builder
           .Property(e => e.StatusId)
           .IsRequired();

            builder
           .Property(e => e.Username)
           .IsRequired();

            



        }
    }
}
