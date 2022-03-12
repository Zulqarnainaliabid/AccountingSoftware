using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Perfactcv.Core.Models;
using Perfactcv.Core.Repositories;

namespace Perfactcv.Data.Repositories
{
    public class MusicRepository : Repository<Music>, IMusicRepository
    {
        public MusicRepository(PerfactcvDbContext context) 
            : base(context)
        { }

        public async Task<IEnumerable<Music>> GetAllWithArtistAsync()
        {
            return await PerfactcvDbContext.Musics
                .Include(m => m.Artist)
                .ToListAsync();
        }

        public async Task<Music> GetWithArtistByIdAsync(int id)
        {
            return await PerfactcvDbContext.Musics
                .Include(m => m.Artist)
                .SingleOrDefaultAsync(m => m.Id == id);;
        }

        public async Task<IEnumerable<Music>> GetAllWithArtistByArtistIdAsync(int artistId)
        {
            return await PerfactcvDbContext.Musics
                .Include(m => m.Artist)
                .Where(m => m.ArtistId == artistId)
                .ToListAsync();
        }
        
        private PerfactcvDbContext PerfactcvDbContext
        {
            get { return Context as PerfactcvDbContext; }
        }
    }
}