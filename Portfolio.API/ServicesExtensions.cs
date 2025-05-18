using Microsoft.Extensions.Options;
using Minio;
using Portfolio.Application.Services;
using Portfolio.Application.Services.TeacherService;
using Portfolio.Domain.Services;

namespace Portfolio.API
{
    public static class ServicesExtensions
    {
        public static IServiceCollection AddAPIServices(this IServiceCollection services)
        {
            services.AddSingleton<IMinioClient>(serviceProvider =>
            {
                var config = serviceProvider.GetRequiredService<IOptions<MinioConfig>>().Value;
                return new MinioClient().WithEndpoint(config.Endpoint).WithCredentials(config.AccessKey, config.SecretKey).WithSSL(config.UseSsl).Build();
            });
            services.AddScoped<IDepartmentService, DepartmentService>();
            services.AddScoped<IDisciplineService, DisciplineService>();
            services.AddScoped<ITeacherService, TeacherService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAdminService, AdminService>();
            services.AddScoped<ITeacherAwardService, TeacherAwardService>();
            services.AddScoped<ITeacherDisciplineService, TeacherDisciplineService>();
            services.AddScoped<ITeacherProfessionalDevelopmentService, TeacherProfessionalDevelopmentService>();
            services.AddScoped<ITeacherDissertationService, TeacherDissertationService>();
            services.AddScoped<ITeacherPublicActivityService, TeacherPublicActivityService>();
            services.AddScoped<ITeacherPublicationService, TeacherPublicationService>();
            services.AddScoped<ITeacherScienceProjectService, TeacherScienceProjectService>();
            services.AddScoped<ITeacherUniversityService, TeacherUniversityService>();
            services.AddScoped<ITeacherWorkService, TeacherWorkService>();
            return services;
        }
    }
}
