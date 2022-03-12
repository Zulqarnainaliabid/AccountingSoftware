using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AccountingApp.Core;
using AccountingApp.Core.Models;
using AccountingApp.Core.Services;

namespace AccountingApp.Services
{
    public class LoanDetailService : ILoanDetailService
    {
        private readonly IUnitOfWork _unitOfWork;
        public LoanDetailService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<LoanDetail> Create(LoanDetail loanDetail)
        {
            loanDetail.DateAdded = DateTime.Now;
            await _unitOfWork.LoanDetails.AddAsync(loanDetail);
            await _unitOfWork.CommitAsync();
            return loanDetail;
        }

        public async Task Update(LoanDetail loanDetailToBeUpdated, LoanDetail loanDetail)
        {
            loanDetailToBeUpdated.Amount = loanDetail.Amount;
            loanDetailToBeUpdated.Description = loanDetail.Description;
            loanDetailToBeUpdated.ImagePath = loanDetail.ImagePath;
            loanDetailToBeUpdated.LoanTakerId = loanDetail.LoanTakerId;
            loanDetailToBeUpdated.Status = loanDetail.Status;
            await _unitOfWork.CommitAsync();
        }

        public async Task Delete(LoanDetail loanDetail)
        {
            _unitOfWork.LoanDetails.Remove(loanDetail);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<LoanDetail>> GetAllLoanDetails(Guid userId)
        {
            return await _unitOfWork.LoanDetails
                .GetAllAsync(userId);
        }

        public async Task<IEnumerable<LoanDetail>> GetAllWithLoanTaker(int id)
        {
            return await _unitOfWork.LoanDetails
                .GetAllWithLoanTakerIdAsync(id);
        }

        public async Task<LoanDetail> GetByIdAsync(int id)
        {
            return await _unitOfWork.LoanDetails
                .GetByIdAsync(id);
        }

        public Task<IEnumerable<LoanDetail>> GetLoansByTakerId(int id)
        {
            throw new NotImplementedException();
        }
    }
}