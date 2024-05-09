using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Kooi.Domain.Repositories;
using Persistence.Repositories;
using Persistence;
using Kooi.Application.Data;
using Microsoft.EntityFrameworkCore;
using Kooi.Application.Services;
using Kooi.Infrastructure.Services;
using Kooi.Application.Abstractions.Authentication;
using Infrastructure.Authentication;
using Kooi.Infrastructure.Persistence.Repositories;
using Kooi.Infrastructure.Persistence;
using Microsoft.Extensions.Options;

namespace Kooi.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            ConfigurationManager configuration
            )
        {

            FirebaseApp.Create(new AppOptions
            {
                Credential = GoogleCredential.FromFile("kooi-firebase.json")
            });

            services.AddSingleton<IAuthenticationService, AuthenticationService>();

            services.AddHttpClient<IJwtProvider, JwtProvider>(httpClient =>
            {
                httpClient.BaseAddress = new Uri(configuration["Authentication:TokenUri"]);
            });

            services.AddAuthentication().AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, jwtOptions =>
            {
                jwtOptions.Authority = configuration["Authentication:ValidIssuer"];
                jwtOptions.Audience = configuration["Authentication:Audience"];
                jwtOptions.TokenValidationParameters.ValidIssuer = configuration["Authentication:ValidIssuer"];
            });

            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(
                "Data Source=host.docker.internal,1433;Initial Catalog=KooiDesign;User Id=sa;Password=KooeeAnu233;TrustServerCertificate=true", 
                sqlServerAction =>
                {
                    //'SqlServerRetryingExecutionStrategy' does not support user-initiated transactions
                    //sqlServerAction.EnableRetryOnFailure(3);
                    sqlServerAction.CommandTimeout(30);
                })
            );
            //options.ExecutionStrategy(); //investigate this for transaction

            services.AddScoped<IApplicationDbContext>(sp =>
                sp.GetRequiredService<ApplicationDbContext>());

            services.AddScoped<IAdminUsersRepository, AdminUsersRepository>();
            services.AddScoped<IUsersRepository, UsersRepository>();
            services.AddScoped<ITourRepository, TourRepository>();
            services.AddScoped<ITourStepsRepository, TourStepsRepository>();
            services.AddScoped<ITourAuditLogRepository, TourAuditLogRepository>();
            services.AddScoped<IRouteRepository, RouteRepository>();
            services.AddScoped<IDateTimeProvider, DateTimeProvider>();
            services.AddScoped<ITooltipsRepository, TooltipsRepository>();
            services.AddScoped<ITooltipInstructionsRepository, TooltipInstructionsRepository>();
            services.AddScoped<IContentTypesRepository, ContentTypesRepository>();
            services.AddScoped<IAlignmentsRepository, AlignmentsRepository>();
            services.AddScoped<ISidesRepository, SidesRepository>();
            services.AddScoped<IRolesRepository, RolesRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
}