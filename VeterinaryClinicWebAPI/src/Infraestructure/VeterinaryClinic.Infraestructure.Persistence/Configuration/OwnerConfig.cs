using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VeterinaryClinic.Core.Domain.Entities;

namespace VeterinaryClinic.Infraestructure.Persistence.Configuration
{
	public class OwnerConfig: IEntityTypeConfiguration<Owner>
	{
		
		public void Configure(EntityTypeBuilder<Owner> builder)
		{
			builder.ToTable("owners");

			builder.HasKey(p => p.Id);

			builder.Property(p => p.FullName)
				.HasMaxLength(80)
				.IsRequired();

			builder.Property(p => p.CI)
				.HasMaxLength(8)
				.IsRequired();

			builder.Property(p => p.Adress)
				.HasMaxLength(150);

			builder.Property(p => p.Contact)
				.HasMaxLength(9)
				.IsRequired();

			builder.Property(p => p.Email)
				.HasMaxLength(90);

			builder.Property(p => p.CreatedBy)
				.HasMaxLength(30);

			builder.Property(p => p.LastModifiedBy)
				.HasMaxLength(30);
		}
	}
}

