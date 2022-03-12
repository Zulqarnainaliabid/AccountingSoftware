using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AccountingApp.Core.Models;

namespace AccountingApp.Core.Services
{
    public interface ILoanTakerService
    {
        Task<IEnumerable<LoanTaker>> GetAllAsync(Guid userId);
        Task<LoanTaker> GetByIdAsync(int id);
        Task<LoanTaker> Create(LoanTaker loanTaker);
        Task Update(LoanTaker loanTakerToBeUpdated, LoanTaker loanTaker);
        Task Delete(LoanTaker loanTaker);
    }
}