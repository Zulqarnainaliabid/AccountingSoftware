using AccountingApp.Core;
using AccountingApp.Core.Models;
using AccountingApp.Core.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AccountingApp.Services
{
    public class LoanTakerService : ILoanTakerService
    {
        private readonly IUnitOfWork _unitOfWork;
        public LoanTakerService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<LoanTaker>> GetAllAsync(Guid userId)
        {
            return await _unitOfWork.LoanTakers.GetAllAsync(userId);
        }

        public async Task<LoanTaker> GetByIdAsync(int id)
        {
            return await _unitOfWork.LoanTakers.GetByIdAsync(id);
        }

        public async Task<LoanTaker> Create(LoanTaker loanTaker)
        {
            await _unitOfWork.LoanTakers
                .AddAsync(loanTaker);
            await _unitOfWork.CommitAsync();                    
            
            return loanTaker;
        }

        public async Task Update(LoanTaker loanTakerToBeUpdated, LoanTaker loanTaker)
        {
            loanTakerToBeUpdated.Name = loanTaker.Name;
            loanTakerToBeUpdated.Contact = loanTaker.Contact;
            await _unitOfWork.CommitAsync();
        }

        public async Task Delete(LoanTaker loanTaker)
        {
            _unitOfWork.LoanTakers.Remove(loanTaker);
            await _unitOfWork.CommitAsync();
        }
    }
}
