using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Perfactcv.Core.Models;
using Perfactcv.Core.Repositories;

namespace Perfactcv.Data.Repositories
{
    public class ArtistRepository : Repository<Artist>, IArtistRepository
    {
        public ArtistRepository(PerfactcvDbContext context) 
            : base(context)
        { }
        public async Task<IEnumerable<Artist>> GetAllWithMusicsAsync()
        {
            return await PerfactcvDbContext.Artists
                .Include(a => a.Musics)
                .ToListAsync();
        }

        public Task<Artist> GetWithMusicsByIdAsync(int id)
        {
            return PerfactcvDbContext.Artists
                .Include(a => a.Musics)
                .SingleOrDefaultAsync(a => a.Id == id);
        }

        private PerfactcvDbContext PerfactcvDbContext
        {
            get { return Context as PerfactcvDbContext; }
        }
    }
}