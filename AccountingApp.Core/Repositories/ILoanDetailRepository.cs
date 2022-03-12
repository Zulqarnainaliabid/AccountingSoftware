using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AccountingApp.Core.Models;

namespace AccountingApp.Core.Repositories
{
    public interface ILoanDetailRepository : IRepository<LoanDetail>
    {
        Task<IEnumerable<LoanDetail>> GetAllAsync(Guid userId);
        Task<IEnumerable<LoanDetail>> GetAllWithLoanTakerIdAsync(int loanTakerId);
        Task<IEnumerable<LoanDetail>> GetWithDateRangeByLoanTakerIdAsync(int loanTakerId,DateTime dateStart,DateTime dateEnd);
        Task<IEnumerable<LoanDetail>> GetWithDateByLoanTakerIdAsync(int loanTakerId, DateTime date);
    }
}