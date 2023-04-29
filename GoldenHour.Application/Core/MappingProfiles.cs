using AutoMapper;

namespace GoldenHour.Application.Core
{
    public class MappingProfiles : Profile
    {

        public MappingProfiles()
        {
            Dictionary<string, string>? usersRoles = null;

            CreateProjection<Domain.ServiceMan, DTO.Users.ServiceMan>()
                .ForMember(x => x.BloodGroupName, o => o.MapFrom(x => x.BloodGroup.Name))
                .ForMember(x => x.BrigadeShortName, o => o.MapFrom(x => x.Brigade.ShortName))
                .ForMember(x => x.Roles, o => o.MapFrom(x => usersRoles != null ? usersRoles[x.Id] : string.Empty));
        }
    }
}
