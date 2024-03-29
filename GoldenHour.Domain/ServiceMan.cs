﻿using Microsoft.AspNetCore.Identity;

namespace GoldenHour.Domain
{
    public class ServiceMan : IdentityUser
    {
        public string NickName { get; set; }
        public string FullName { get; set; }
        public BloodGroup BloodGroup { get;set; }
        public Guid BloodGroupId { get;set; }
        public Brigade Brigade { get; set; }
        public Guid BrigadeId { get; set; }
        public List<Incident> Incidents { get; set; }
        public List<Incident> HelpedIncidents { get; set; }
        public List<UserRefreshToken> UserRefreshTokens { get; set; }

    }
}
