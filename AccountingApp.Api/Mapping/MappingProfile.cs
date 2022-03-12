using AutoMapper;
using AccountingApp.Api.Resources;
using AccountingApp.Core.Models;
using AccountingApp.Core.Models.Auth;

namespace AccountingApp.Api.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Domain to Resource
            CreateMap<LoanDetail, LoanDetailResource>();
            CreateMap<LoanTaker, LoanTakerResource>();
            
            // Resource to Domain
            CreateMap<LoanDetailResource, LoanDetail>();
            CreateMap<SaveLoanDetailResource, LoanDetail>();
            CreateMap<LoanTakerResource, LoanTaker>();
            CreateMap<SaveLoanTakerResource, LoanTaker>();
            CreateMap<UserSignUpResource, User>()
                .ForMember(u => u.UserName, opt => opt.MapFrom(ur => ur.Email));
        }
    }
}