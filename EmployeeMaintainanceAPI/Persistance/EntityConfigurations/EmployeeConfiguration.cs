using EmployeeMaintainanceAPI.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmployeeMaintainanceAPI.Persistance.EntityConfigurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(e => e.EmployeeId);

            builder.Property(p => p.PersonId)
                .IsRequired();
            builder.Property(e => e.EmployeeNum)
                .IsRequired()
                .HasMaxLength(16);
            builder.Property(ed => ed.EmployedDate)
                .IsRequired();

        }
    }
}
