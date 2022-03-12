using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Perfactcv.Core;
using Perfactcv.Core.Models;
using Perfactcv.Core.Services;

namespace Perfactcv.Services
{
    public class CVBackupService : ICVBackupService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CVBackupService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<CVBackup> Create(CVBackup newCV)
        {
            await _unitOfWork.CVBackups.AddAsync(newCV);
            await _unitOfWork.CommitAsync();
            return newCV;
        }

        public async Task Delete(CVBackup cv)
        {
            _unitOfWork.CVBackups.Remove(cv);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<CVBackup>> GetAll()
        {
            return await _unitOfWork.CVBackups
                .GetAllAsync();
        }

        public async Task<IEnumerable<CVBackup>> GetAllWithUserId(Guid id)
        {
            return await _unitOfWork.CVBackups
                .GetWithUserIdAsync(id);
        }

        public async Task<CVBackup> GetById(int id)
        {
            return await _unitOfWork.CVBackups
                .GetByIdAsync(id);
        }

        public async Task Update(CVBackup toBeUpdated, CVBackup updatedCV)
        {
            toBeUpdated.Subject = updatedCV.Subject;
            toBeUpdated.Data = updatedCV.Data;
            toBeUpdated.DateUpdated = DateTime.Now;

            await _unitOfWork.CommitAsync();
        }
    }
}