using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AccountingApp.Core.Models;
using AccountingApp.Core.Repositories;

namespace AccountingApp.Data.Repositories
{
    public class LoanDetailRepository : Repository<LoanDetail>, ILoanDetailRepository
    {
        public LoanDetailRepository(AccountingAppDbContext context) 
            : base(context)
        { }

        public async Task<IEnumerable<LoanDetail>> GetAllWithLoanTakerIdAsync()
        {
            return await AccountingAppDbContext.LoanDetails
                .Include(m => m.LoanTaker)
                .ToListAsync();
        }

        public async Task<IEnumerable<LoanDetail>> GetAllWithLoanTakerIdAsync(int loanTakerId)
        {
            return await AccountingAppDbContext.LoanDetails
                .Include(m => m.LoanTaker)
                .Where(m => m.LoanTakerId == loanTakerId).ToListAsync();
        }

        public async Task<IEnumerable<LoanDetail>> GetWithDateRangeByLoanTakerIdAsync(int loanTakerId, DateTime dateStart, DateTime dateEnd)
        {
            return await AccountingAppDbContext.LoanDetails
                .Where(x => 
                x.LoanTakerId == loanTakerId 
                && x.DateAdded.Subtract(dateStart).TotalSeconds >= 0 && 
                x.DateAdded.Subtract(dateEnd).TotalSeconds <= 0 ).ToListAsync();
        }

        public async Task<IEnumerable<LoanDetail>> GetWithDateByLoanTakerIdAsync(int loanTakerId, DateTime date)
        {
            return await AccountingAppDbContext.LoanDetails
                .Where(x =>
                x.LoanTakerId == loanTakerId
                && x.DateAdded.Date.Subtract(date.Date).TotalSeconds == 0 
                ).ToListAsync();
        }

        public async Task<IEnumerable<LoanDetail>> GetAllAsync(Guid userId)
        {
            return await AccountingAppDbContext.LoanDetails
                .Include(x => x.LoanTaker)
                .Where(x => x.LoanTaker.UserId == userId).ToListAsync();
        }

        private AccountingAppDbContext AccountingAppDbContext
        {
            get { return Context as AccountingAppDbContext; }
        }
    }
}