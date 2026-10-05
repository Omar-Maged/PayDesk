using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PayDesk.Domain;

namespace PayDesk.Infrastructure.Configurations
{
    internal class TerminalConfiguration : IEntityTypeConfiguration<Terminal>
    {
        public void Configure(EntityTypeBuilder<Terminal> builder) 
        {
            builder.ToTable("Terminals");

            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id)
                .HasColumnName("TerminalId");

            builder.Property(t => t.TerminalCode)
                .HasColumnName("TerminalCode")
                .HasMaxLength(8)
                .IsRequired();

            builder.HasIndex(t => t.TerminalCode)
               .IsUnique();

            builder.Property(t => t.MerchantId)
                .HasColumnName("MerchantId")
                .IsRequired();

            builder.Property(m => m.Channel)
                .HasColumnName("Channel")
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(t => t.Status)
                .HasColumnName("Status")
                .HasConversion<string>()
                .HasMaxLength(20)
                .IsRequired();

            builder.HasOne(t => t.Merchant)
                .WithMany()
                .HasForeignKey(t => t.MerchantId)
                .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
