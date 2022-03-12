using System.Threading.Tasks;
using AccountingApp.Core;
using AccountingApp.Core.Repositories;
using AccountingApp.Data.Repositories;

namespace AccountingApp.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AccountingAppDbContext _context;
        private LoanTakerRepository _loanTakerRepository;
        private LoanDetailRepository _loanDetailRepository;

        public UnitOfWork(AccountingAppDbContext context)
        {
            this._context = context;
        }

        public ILoanTakerRepository LoanTakers => _loanTakerRepository ??= new LoanTakerRepository(_context);

        public ILoanDetailRepository LoanDetails => _loanDetailRepository ??= new LoanDetailRepository(_context);

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}