using System;
using System.Threading.Tasks;
using Perfactcv.Core.Repositories;

namespace Perfactcv.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IMusicRepository Musics { get; }
        ICVBackupRepository CVBackups { get; }
        IArtistRepository Artists { get; }
        Task<int> CommitAsync();
    }
}