using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Perfactcv.Core.Models;

namespace Perfactcv.Core.Services
{
    public interface ICVBackupService
    {
        Task<IEnumerable<CVBackup>> GetAll();
        Task<IEnumerable<CVBackup>> GetAllWithUserId(Guid id);
        Task<CVBackup> GetById(int id);
        Task<CVBackup> Create(CVBackup cvBackup);
        Task Update(CVBackup toBeUpdated, CVBackup cv);
        Task Delete(CVBackup id);
    }
}