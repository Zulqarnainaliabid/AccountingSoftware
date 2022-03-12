using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using AccountingApp.Core.Models;
using AccountingApp.Core.Models.Auth;
using AccountingApp.Data.Configurations;

namespace AccountingApp.Data
{
    public class AccountingAppDbContext : IdentityDbContext<User, Role, Guid>
    {
        public DbSet<LoanDetail> LoanDetails { get; set; }
        public DbSet<LoanTaker> LoanTakers { get; set; }

        public AccountingAppDbContext(DbContextOptions<AccountingAppDbContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            builder
                .ApplyConfiguration(new LoanDetailConfiguration());

            builder
                .ApplyConfiguration(new LoanTakerConfiguration());
        }
    }
}
