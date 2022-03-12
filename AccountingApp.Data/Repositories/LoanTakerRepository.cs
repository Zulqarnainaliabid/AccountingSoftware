using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AccountingApp.Core.Models;
using AccountingApp.Core.Repositories;

namespace AccountingApp.Data.Repositories
{
    public class LoanTakerRepository : Repository<LoanTaker>, ILoanTakerRepository
    {
        public LoanTakerRepository(AccountingAppDbContext context) 
            : base(context)
        { }

        public async Task<IEnumerable<LoanTaker>> GetAllAsync(Guid userId)
        {
            return await AccountingAppDbContext.LoanTakers
                .Include(a => a.LoanDetails)
                .Where(x=>x.UserId==userId)
                .ToListAsync();
        }

        public async Task<IEnumerable<LoanTaker>> GetAllWithLoanDetailAsync()
        {
            return await AccountingAppDbContext.LoanTakers
                .Include(a => a.LoanDetails)
                .ToListAsync();
        }

        public Task<LoanTaker> GetWithLoanDetailByIdAsync(int id)
        {
            return AccountingAppDbContext.LoanTakers
                .Include(a => a.LoanDetails)
                .SingleOrDefaultAsync(a => a.Id == id);
        }

        private AccountingAppDbContext AccountingAppDbContext
        {
            get { return Context as AccountingAppDbContext; }
        }
    }
}