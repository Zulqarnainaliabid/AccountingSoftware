using AccountingApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AccountingApp.Core.Repositories
{
    public interface ILoanTakerRepository : IRepository<LoanTaker>
    {
        Task<IEnumerable<LoanTaker>> GetAllAsync(Guid userId);
    }
}