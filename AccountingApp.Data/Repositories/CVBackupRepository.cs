using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Perfactcv.Core.Models;
using Perfactcv.Core.Repositories;

namespace Perfactcv.Data.Repositories
{
    public class CVBackupRepository : Repository<CVBackup>, ICVBackupRepository
    {
        public CVBackupRepository(PerfactcvDbContext context) 
            : base(context)
        { }

        public async Task<IEnumerable<CVBackup>> GetWithUserIdAsync(Guid id)
        {
            return await PerfactcvDbContext.CVBackups.Where(x=>x.UserId==id)
                .ToListAsync();
        }

        private PerfactcvDbContext PerfactcvDbContext
        {
            get { return Context as PerfactcvDbContext; }
        }
    }
}