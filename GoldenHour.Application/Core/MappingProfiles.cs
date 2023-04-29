using AutoMapper;
using GoldenHour.DTO;
using Microsoft.AspNetCore.Identity;

namespace GoldenHour.Application.Core
{
    public class MappingProfiles : Profile
    {

        public MappingProfiles()
        {
            Dictionary<string, string>? usersRoles = null;
            Dictionary<string, string>? roles = null;

            CreateProjection<Domain.ServiceMan, DTO.Users.ServiceMan>()
                .ForMember(x => x.BloodGroupName, o => o.MapFrom(x => x.BloodGroup.Name))
                .ForMember(x => x.BrigadeShortName, o => o.MapFrom(x => x.Brigade.ShortName))
                .ForMember(x => x.Role, o => o.MapFrom(x => usersRoles != null ? usersRoles[x.Id] : string.Empty))
                .ForMember(x => x.RoleId, o => o.MapFrom(x => roles != null && usersRoles != null 
                    ? roles[usersRoles[x.Id]] : string.Empty));

            CreateMap<DTO.Users.ServiceMan, Domain.ServiceMan>();
            CreateMap<Domain.ServiceMan, Domain.ServiceMan>();

            CreateMap<IdentityRole, BaseEntity>();
            CreateMap<Domain.BloodGroup, BaseEntity>();
            CreateMap<Domain.Brigade, BaseEntity>();
        }
    }
}
