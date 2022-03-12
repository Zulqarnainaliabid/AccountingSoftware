using System;
using System.Threading.Tasks;
using AccountingApp.Core.Repositories;

namespace AccountingApp.Core
{
    public interface IUnitOfWork : IDisposable
    {
        ILoanTakerRepository LoanTakers { get; }
        ILoanDetailRepository LoanDetails{ get; }
        Task<int> CommitAsync();
    }
}