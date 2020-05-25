using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tut11.Entities;

namespace tut11.Configuration
{
    public class PrescriptionMedicamentConfiguration : IEntityTypeConfiguration<Prescription_Medicament>
    {
        public void Configure(EntityTypeBuilder<Prescription_Medicament> builder)
        {
            builder.HasKey(e => e.IdMedicament);
            builder.HasKey(e => e.IdPrescription);

            builder.Property(e => e.IdMedicament).IsRequired();
            builder.Property(e => e.IdPrescription).IsRequired();

            builder.Property(e => e.Dose).IsRequired(false);

            builder.Property(e => e.Details)
                .IsRequired()
                .HasMaxLength(100);

            builder.ToTable("Prescription_Medicament");
        }
    }
}
