using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Perfactcv.Core.Models;
using Perfactcv.Core.Models.Auth;
using Perfactcv.Data.Configurations;

namespace Perfactcv.Data
{
    public class PerfactcvDbContext : IdentityDbContext<User, Role, Guid>
    {
        public DbSet<Music> Musics { get; set; }
        public DbSet<CVBackup> CVBackups { get; set; }
        public DbSet<Artist> Artists { get; set; }

        public PerfactcvDbContext(DbContextOptions<PerfactcvDbContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            builder
                .ApplyConfiguration(new MusicConfiguration());

            builder
                .ApplyConfiguration(new ArtistConfiguration());
        }
    }
}
