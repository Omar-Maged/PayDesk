using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PayDesk.Domain;

namespace PayDesk.Infrastructure.Configurations
{
    internal class TransactionConfiguration
        : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.ToTable("Transactions");

            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id)
                .HasColumnName("TransactionId");

            builder.Property(t => t.Reference)
                .HasColumnName("Reference")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(t => t.MerchantId)
                .HasColumnName("MerchantId")
                .IsRequired();

            builder.Property(t => t.TerminalId)
                .HasColumnName("TerminalId")
                .IsRequired();

            builder.OwnsOne(t => t.Amount, money =>
            {
                money.Property(m => m.Amount)
                    .HasColumnName("Amount")
                    .IsRequired();

                money.Property(m => m.Currency)
                    .HasColumnName("Currency")
                    .HasMaxLength(3)
                    .IsRequired();
            });

            builder.OwnsOne(t => t.Card, card =>
            {
                card.Property(c => c.StoredDigits)
                    .HasColumnName("CardMaskedData")
                    .HasColumnType("char(10)")
                    .IsRequired();

                card.Property(c => c.Scheme)
                    .HasColumnName("CardScheme")
                    .HasMaxLength(20)
                    .IsRequired();

                card.Ignore(c => c.MaskedNumber);
            });

            builder.Property(t => t.Status)
                .HasColumnName("Status")
                .HasConversion<string>()
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(t => t.CreatedAtUtc)
                .HasColumnName("CreatedAtUtc")
                .IsRequired();

            builder.HasOne(t => t.Merchant)
                .WithMany()
                .HasForeignKey(t => t.MerchantId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(t => t.Terminal)
                .WithMany()
                .HasForeignKey(t => t.TerminalId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}