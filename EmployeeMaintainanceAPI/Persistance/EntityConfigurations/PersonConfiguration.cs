using EmployeeMaintainanceAPI.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmployeeMaintainanceAPI.Persistance.EntityConfigurations
{
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.HasKey(p => p.PersonId);

            builder.Property(l => l.LastName)
                .IsRequired()
                .HasMaxLength(128);

            builder.Property(f => f.FirstName)
                .IsRequired()
                .HasMaxLength(128);

            builder.Property(b => b.BirthDate)
                .IsRequired();
            
        }
    }
}
