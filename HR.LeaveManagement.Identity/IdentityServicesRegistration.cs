﻿using HR.LeaveManagement.Application.Contracts.Identity;

namespace HR.LeaveManagement.Identity;
public class IdentityServicesRegistration
{
     public static IServiceCollection ConfigureIdentityServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));

        services.AddDbContext<LeaveManagementIdentityDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("LeaveManagementIdentityConnectionString"),
            b => b.MigrationsAssembly(typeof(LeaveManagementIdentityDbContext).Assembly.FullName)
        ));

        services.AddIdentity<ApplicationUser, IdentityRole>()
        .AddEntityFrameworkStores<LeaveManagementIdentityDbContext>()
        .AddDefaultTokenProviders();

        services.AddTransient<IAuthService, AuthService>();
        services.AddTransient<IUserService, UserService>();

        services.AddAuthentication(options => {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(o => {
            o.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero,
                ValidIssuer = configuration["JwtSettings:Issuer"],
                ValidAudience = configuration["JwtSettings:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSettings:Key"]))
            };
        });
        return services;
    }

}