using GoldenHour.Application.Core;
using GoldenHour.Domain;
using GoldenHour.Persistance;
using GoldenHour.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace GoldenHour.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static WebApplicationBuilder AddDbServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<DataContext>(o =>
                o.UseSqlServer(builder.Configuration.GetConnectionString("DataContext")));

            builder.Services.AddIdentityCore<ServiceMan>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<DataContext>();

            return builder;
        }

        public static WebApplicationBuilder AddAuthServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddCors(o =>
            {
                o.AddPolicy("AllowAll", a => a.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());
            });

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = builder.Configuration["JwtSettings:Issuer"],
                    ValidateAudience = true,
                    ValidAudience = builder.Configuration["JwtSettings:Audience"],
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtSettings:Key"]))
                };
            });

            builder.Services.AddAuthorization(options =>
            {
                options.FallbackPolicy = new AuthorizationPolicyBuilder()
                .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
                .RequireAuthenticatedUser()
                .Build();
            });

            builder.Services.AddScoped<TokenService>();

            return builder;
        }

        public static WebApplicationBuilder AddAdditionalServices(this WebApplicationBuilder builder)
        {
            //builder.Services.AddMediatR(typeof(Token.Handler).Assembly);
            builder.Services.AddAutoMapper(typeof(MappingProfiles).Assembly);

            return builder;
        }
    }
}
