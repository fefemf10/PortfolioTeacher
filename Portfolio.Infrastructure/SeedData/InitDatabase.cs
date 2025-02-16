using Portfolio.Domain.Models;
using Portfolio.Infrastructure.Configurations;
using System.Text.Json;

namespace Portfolio.Infrastructure.SeedData
{
	public static class InitDatabase
	{
		public static void Init()
		{
			FileStream disciplineStream = File.OpenRead("SeedData/Discipline.json");
			DisciplineConfiguration.disciplinesData = JsonSerializer.Deserialize<Discipline[]>(disciplineStream);
			FileStream facultyStream = File.OpenRead("SeedData/Faculty.json");
			FacultyConfiguration.facultiesData = JsonSerializer.Deserialize<Faculty[]>(facultyStream);
			FileStream departmentStream = File.OpenRead("SeedData/Department.json");
			DepartmentConfiguration.departmentData = JsonSerializer.Deserialize<Department[]>(departmentStream);
		}
	}
}