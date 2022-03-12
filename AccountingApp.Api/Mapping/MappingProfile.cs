using AutoMapper;
using Perfactcv.Api.Resources;
using Perfactcv.Core.Models;
using Perfactcv.Core.Models.Auth;

namespace Perfactcv.Api.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Domain to Resource
            CreateMap<Music, MusicResource>();
            CreateMap<CVBackup, CVBackupResource>();
            CreateMap<Artist, ArtistResource>();
            
            // Resource to Domain
            CreateMap<MusicResource, Music>();
            CreateMap<SaveMusicResource, Music>();
            CreateMap<SaveCVBackupResource, CVBackup>();
            CreateMap<ArtistResource, Artist>();
            CreateMap<SaveArtistResource, Artist>();
            CreateMap<UserSignUpResource, User>()
                .ForMember(u => u.UserName, opt => opt.MapFrom(ur => ur.Email));
        }
    }
}