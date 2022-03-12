using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AccountingApp.Core.Models;

namespace AccountingApp.Core.Services
{
    public interface ILoanDetailService
    {
        Task<LoanDetail> GetByIdAsync(int id);
        Task<IEnumerable<LoanDetail>> GetAllLoanDetails(Guid userId);
        Task<IEnumerable<LoanDetail>> GetLoansByTakerId(int id);
        Task<LoanDetail> Create(LoanDetail newLoanDetail);
        Task Update(LoanDetail loanDetailToBeUpdated, LoanDetail loanDetail);
        Task Delete(LoanDetail loanDetail);
    }
}