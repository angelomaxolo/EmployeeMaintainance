using System;
using System.Collections.Generic;
using System.Text;
using Employeemaintainance.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmployeeMaintainance.Persistance.Persistance.EntityConfigurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(e => e.EmployeeId);

            builder.Property(e => e.EmployeeNum)
                .IsRequired()
                .HasMaxLength(16);
            builder.Property(ed => ed.EmployedDate)
                .IsRequired();

        }
    }
}
