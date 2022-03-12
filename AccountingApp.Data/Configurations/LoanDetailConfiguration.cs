using AccountingApp.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AccountingApp.Data.Configurations
{
    public class LoanDetailConfiguration : IEntityTypeConfiguration<LoanDetail>
    {
        public void Configure(EntityTypeBuilder<LoanDetail> builder)
        {
            builder
                .HasKey(m => m.Id);

            builder
                .Property(m => m.Id)
                .UseIdentityColumn();

            builder
                .Property(m => m.Amount)
                .IsRequired();

            builder
                .HasOne(m => m.LoanTaker)
                .WithMany(a => a.LoanDetails)
                .HasForeignKey(m => m.LoanTakerId);

            builder
                .ToTable("LoanDetails");
        }
    }
}