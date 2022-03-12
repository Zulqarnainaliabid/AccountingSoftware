using System.Threading.Tasks;
using Perfactcv.Core;
using Perfactcv.Core.Repositories;
using Perfactcv.Data.Repositories;

namespace Perfactcv.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PerfactcvDbContext _context;
        private CVBackupRepository _cvBackupRepository;
        private MusicRepository _musicRepository;
        private ArtistRepository _artistRepository;

        public UnitOfWork(PerfactcvDbContext context)
        {
            this._context = context;
        }

        public IArtistRepository Artists => _artistRepository ??= new ArtistRepository(_context);

        public IMusicRepository Musics => _musicRepository ??= new MusicRepository(_context);

        public ICVBackupRepository CVBackups => _cvBackupRepository ??= new CVBackupRepository(_context);

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