using AutoMapper;
using GoldenHour.DTO;
using Microsoft.AspNetCore.Identity;
using System.Globalization;

namespace GoldenHour.Application.Core
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            Dictionary<string, string>? usersRoles = null;
            Dictionary<string, string>? roles = null;

            CreateMap<Domain.ServiceMan, DTO.Users.ServiceMan>()
                .ForMember(x => x.BloodGroupName, o => o.MapFrom(x => x.BloodGroup.Name))
                .ForMember(x => x.BrigadeShortName, o => o.MapFrom(x => x.Brigade.ShortName))
                .ForMember(x => x.Role, o => o.MapFrom(x => usersRoles != null ? usersRoles[x.Id] : string.Empty))
                .ForMember(x => x.RoleId, o => o.MapFrom(x => roles != null && usersRoles != null 
                    ? roles[usersRoles[x.Id]] : string.Empty));

            CreateMap<DTO.Users.ServiceMan, Domain.ServiceMan>();
            CreateMap<Domain.ServiceMan, Domain.ServiceMan>()
                .ConvertUsing((src, dest) =>
                {
                    dest.UserName = src.UserName;
                    dest.FullName = src.FullName;
                    dest.NickName = src.NickName;
                    dest.Email = src.Email;
                    dest.BloodGroupId = src.BloodGroupId;
                    dest.BrigadeId = src.BrigadeId;

                    return dest;
                });

            CreateMap<DTO.Incidents.IncidentCreate, Domain.Incident>();

            CreateMap<IdentityRole, BaseEntity>();
            CreateMap<Domain.BloodGroup, BaseEntity>();
            CreateMap<Domain.Brigade, BaseEntity>();

            CreateMap<Domain.Incident, DTO.Incidents.Incident>()
                .ForMember(x => x.MedicFullName, o => o.MapFrom(x => x.Medic.FullName))
                .ForMember(x => x.DateTime, o => o.MapFrom(x => x.DateTime.ToString("MM/dd/yyyy HH:mm", CultureInfo.InvariantCulture)));
        }
    }
}
