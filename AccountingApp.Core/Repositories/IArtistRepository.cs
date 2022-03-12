using System.Collections.Generic;
using System.Threading.Tasks;
using Perfactcv.Core.Models;

namespace Perfactcv.Core.Repositories
{
    public interface IArtistRepository : IRepository<Artist>
    {
        Task<IEnumerable<Artist>> GetAllWithMusicsAsync();
        Task<Artist> GetWithMusicsByIdAsync(int id);
    }
}