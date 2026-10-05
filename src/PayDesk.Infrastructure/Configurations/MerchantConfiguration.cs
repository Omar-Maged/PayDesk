using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PayDesk.Domain;

namespace PayDesk.Infrastructure.Configurations
{
    public class MerchantConfiguration : IEntityTypeConfiguration<Merchant>
    {
        public void Configure(EntityTypeBuilder<Merchant> builder)
        {
            builder.ToTable("Merchants");

            builder.HasKey(m => m.Id);

            builder.Property(m => m.Id).HasColumnName("MerchantId");

            builder.Property(m => m.Name)
                .HasColumnName("Name")
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(m => m.City)
                .HasColumnName("City")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(m => m.ContactEmail)
                .HasColumnName("ContactEmail")
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(m => m.MerchantCode)
                .HasColumnName("MerchantCode")
                .HasMaxLength(6)
                .IsRequired();

            builder.HasIndex(m => m.MerchantCode)
                .IsUnique();

            builder.Property(m => m.Status)
                .HasColumnName("Status")
                .HasConversion<string>()
                .HasMaxLength(20)
                .IsRequired();
        }
    }
}