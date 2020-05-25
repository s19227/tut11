﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tut11.Entities;

namespace tut11.Configuration
{
    public class MedicamentConfiguration : IEntityTypeConfiguration<Medicament>
    {
        public void Configure(EntityTypeBuilder<Medicament> builder)
        {
            builder.HasKey(e => e.IdMedicament);
            builder.Property(e => e.IdMedicament).IsRequired();

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(e => e.Description)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(e => e.Type)
                .IsRequired()
                .HasMaxLength(100);

            builder
                .HasMany(e => e.Prescription_Medicaments)
                .WithOne(p => p.Medicament)
                .HasForeignKey(p => p.IdMedicament)
                .IsRequired();

            builder.ToTable("Medicament");
        }
    }
}
