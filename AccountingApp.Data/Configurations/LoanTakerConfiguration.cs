using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AccountingApp.Core.Models;

namespace AccountingApp.Data.Configurations
{
    public class LoanTakerConfiguration : IEntityTypeConfiguration<LoanTaker>
    {
        public void Configure(EntityTypeBuilder<LoanTaker> builder)
        {
            builder
                .HasKey(a => a.Id);

            builder
                .Property(m => m.Id)
                .UseIdentityColumn();
                
            builder
                .Property(m => m.Name)
                .IsRequired()
                .HasMaxLength(150);

            builder
                .Property(m => m.Contact)
                .IsRequired()
                .HasMaxLength(1000);

            builder
                .ToTable("LoanTakers");
        }
    }
}