using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tut11.Entities;

namespace tut11.Configuration
{
    public class PrescriptionConfiguration: IEntityTypeConfiguration<Prescription>
    {
        public void Configure(EntityTypeBuilder<Prescription> builder)
        {
            builder.HasKey(e => e.IdPrescription);
            builder.Property(e => e.IdPrescription).ValueGeneratedOnAdd();

            builder.Property(e => e.Date).IsRequired();
            builder.Property(e => e.DueDate).IsRequired();

            builder
                .HasMany(e => e.Prescription_Medicaments)
                .WithOne(p => p.Prescription)
                .HasForeignKey(p => p.IdPrescription)
                .IsRequired();

            builder.ToTable("Prescription");
        }
    }
}
