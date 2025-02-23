using Portfolio.Application.Services;
using Portfolio.Application.Services.TeacherService;
using Portfolio.Domain.Services;

namespace Portfolio.API
{
    public static class ServicesExtensions
    {
        public static IServiceCollection AddAPIServices(this IServiceCollection services)
        {
            services.AddScoped<IFacultyService, FacultyService>();
            services.AddScoped<IDepartmentService, DepartmentService>();
            services.AddScoped<IDisciplineService, DisciplineService>();
            services.AddScoped<ITeacherService, TeacherService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ITeacherAwardService, TeacherAwardService>();
            services.AddScoped<ITeacherDisciplineService, TeacherDisciplineService>();
            services.AddScoped<ITeacherDepartmentService, TeacherDepartmentService>();
            services.AddScoped<ITeacherDissertationService, TeacherDissertationService>();
            services.AddScoped<ITeacherProfessionalDevelopmentService, TeacherProfessionalDevelopmentService>();
            services.AddScoped<ITeacherPublicActivityService, TeacherPublicActivityService>();
            services.AddScoped<ITeacherPublicationService, TeacherPublicationService>();
            services.AddScoped<ITeacherScienceProjectService, TeacherScienceProjectService>();
            services.AddScoped<ITeacherUniversityService, TeacherUniversityService>();
            services.AddScoped<ITeacherWorkService, TeacherWorkService>();
            return services;
        }
    }
}
