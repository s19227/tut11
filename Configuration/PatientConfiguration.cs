using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tut11.Entities;

namespace tut11.Configuration
{
    public class PatientConfiguration : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.HasKey(e => e.IdPatient);
            builder.Property(e => e.IdPatient).IsRequired();

            builder.Property(e => e.FirstName)
               .IsRequired()
               .HasMaxLength(100);

            builder.Property(e => e.LastName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(e => e.BirthDate).IsRequired();

            builder
                .HasMany(e => e.Prescriptions)
                .WithOne(p => p.Patient)
                .HasForeignKey(p => p.IdPatient)
                .IsRequired();

            builder.ToTable("Patient");
        }
    }
}
