using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Perfactcv.Core.Models;

namespace Perfactcv.Core.Repositories
{
    public interface ICVBackupRepository : IRepository<CVBackup>
    {
        Task<IEnumerable<CVBackup>> GetWithUserIdAsync(Guid id);
    }
}