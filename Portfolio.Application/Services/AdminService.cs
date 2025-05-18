using Portfolio.Application.Exceptions;
using Portfolio.Application.ViewModels.Request;
using Portfolio.Domain.Models;
using Portfolio.Domain.Services;
using Portfolio.Infrastructure;
using System.ComponentModel.DataAnnotations;

namespace Portfolio.Application.Services
{
	public class AdminService(ApplicationContext db, IDepartmentService ds) : IAdminService
	{
		public static List<T> GenerateRandomLengthArray<T>(Func<T> itemGenerator, int maxLength = 10)
		{
			if (maxLength <= 0)
				throw new ArgumentException("Max length must be positive", nameof(maxLength));

			int length = Random.Shared.Next(1, maxLength + 1);
			List<T> list = new(length);
			for (int i = 0; i < length; i++)
				list.Add(itemGenerator());
			return list;
		}
		public async Task AddTestUsers(List<Teacher> requestAddTeachers)
		{
			foreach (var requestAddTeacher in requestAddTeachers)
			{
				List<Work> works = GenerateRandomLengthArray(() =>
				{
					return new Work()
					{
						Name = $"Работа {Random.Shared.Next(1, 10)}",
						Post = $"Должность {Random.Shared.Next(1, 10)}",
						BeginTimeWork = GetDateMinMax(1980, 2024),
					};
				});
				List<University> universities = GenerateRandomLengthArray(() =>
				{
					return new University
					{
						Name = $"Университет {Random.Shared.Next(1, 10)}",
						Qualification = $"Квалификация {Random.Shared.Next(1, 10)}",
						Specialization = $"Специализация {Random.Shared.Next(1, 10)}",
						YearGraduation = GetDateMinMax(1980, 2024).Year,
					};
				});
				List<ProfessionalDevelopment> professionalDevelopments = GenerateRandomLengthArray(() =>
				{
					return new ProfessionalDevelopment()
					{
						Name = $"Название {Random.Shared.Next(1, 10)}",
						NameDocument = $"Название документа {Random.Shared.Next(1, 10)}",
						NameOrganization = "Организация",
						ListeningTime = Random.Shared.Next() % 20,
						DateСompletion = GetDateMinMax(2000, 2024),
						NumberDocument = Random.Shared.Next().ToString(),
						SeriaDocument = Random.Shared.Next().ToString(),
					};
				});
				List<ScienceProject> scienceProjects = GenerateRandomLengthArray(() =>
				{
					return new ScienceProject()
					{
						Name = $"Научный проект {Random.Shared.Next(1, 10)}",
						Director = Random.Shared.Next() % 2 == 0,
						BeginTimeWork = GetDateMinMax(2000, 2024),
					};
				});
				List<Dissertation> dissertations = GenerateRandomLengthArray(() =>
				{
					return new Dissertation()
					{
						Topic = $"Диссертация {Random.Shared.Next(1, 10)}",
						YearProtection = Random.Shared.Next(1980, 2025),
						Type = (DissertationType)Random.Shared.Next(1, 4),
						Specialization = $"Специализация {Random.Shared.Next(1, 10)}"
					};
				});
				List<Monography> monographies = GenerateRandomLengthArray(() =>
				{
					return new Monography()
					{
						Name = $"Монография {Random.Shared.Next(1, 10)}",
						Publisher = $"Издатель {Random.Shared.Next(1, 10)}",
						Circulation = Random.Shared.Next(100, 500),
						YearPublication = Random.Shared.Next(1980, 2025),
						CountPages = Random.Shared.Next(50, 200)
					};
				});
				List<Article> articles = GenerateRandomLengthArray(() =>
				{
					return new Article()
					{
						Name = $"Статья {Random.Shared.Next(1, 10)}",
						Journal = $"Журнал {Random.Shared.Next(1, 10)}",
						YearPublication = Random.Shared.Next(1980, 2025),
						URL = "https://ya.ru",
						BeginPage = Random.Shared.Next(1, 50),
						EndPage = Random.Shared.Next(50, 100),
						PrintedSheets = Random.Shared.Next(50, 200),
						IssueNumber = Random.Shared.Next(0, 100)
					};
				});
				List<Thesis> theses = GenerateRandomLengthArray(() =>
				{
					return new Thesis()
					{
						Name = $"Доклад {Random.Shared.Next(1, 10)}",
						Collection = $"Сборник {Random.Shared.Next(1, 10)}",
						YearPublication = Random.Shared.Next(1980, 2025),
						Place = "г. Москва",
						BeginPage = Random.Shared.Next(1, 50),
						EndPage = Random.Shared.Next(50, 100),
						CountPages = Random.Shared.Next(50, 200),
						DateEvent = GetDateMinMax(1980, 2025),
						Type = "Сборник тезисов"
					};
				});
				List<PublicActivity> publicActivities = GenerateRandomLengthArray(() =>
				{
					return new PublicActivity()
					{
						Name = $"Общественный проект {Random.Shared.Next(1, 10)}"
					};
				});
				List<Award> awards = GenerateRandomLengthArray(() =>
				{
					return new Award()
					{
						Name = $"Награда {Random.Shared.Next(1, 10)}",
						NameOrganization = $"Организация {Random.Shared.Next(1, 10)}",
						DateAward = GetDateMinMax(1980, 2024)
					};
				});
				List<Guid> departments = await ds.GetDepartmentIdsByType(DepartmentType.Department);
				List<Guid> faculties = await ds.GetDepartmentIdsByType(DepartmentType.Faculty);
				List<Post> posts = GenerateRandomLengthArray(() =>
				{
					var i = Random.Shared.Next(1, 10);
					Guid depId;
					if (i >= 1 && i <= 8)
						depId = departments[Random.Shared.Next(0, departments.Count())];
					else
						depId = faculties[Random.Shared.Next(0, faculties.Count())];
					return new Post()
					{
					
						PostType = (PostType)i,
						DepartmentId = depId,
					};
				}, 3).DistinctBy(p => p.DepartmentId).DistinctBy(p => p.PostType).ToList();
				await db.Awards.AddRangeAsync(awards);
				await db.PublicActivities.AddRangeAsync(publicActivities);
				await db.ScienceProjects.AddRangeAsync(scienceProjects);
				await db.ProfessionalDevelopments.AddRangeAsync(professionalDevelopments);
				await db.Works.AddRangeAsync(works);
				await db.Universities.AddRangeAsync(universities);
				Teacher teacher = new()
				{
					Id = requestAddTeacher.Id,
					Email = requestAddTeacher.Email,
					LastName = requestAddTeacher.LastName,
					FirstName = requestAddTeacher.FirstName,
					MiddleName = requestAddTeacher.MiddleName,
					Gender = requestAddTeacher.Gender,
					Phone = requestAddTeacher.Phone,
					DateBirthday = GetDateMinMax(1924, DateOnly.FromDateTime(DateTime.Now).Year - 18),
					AcademicDegree = (AcademicDegree)(Random.Shared.Next() % Enum.GetNames<AcademicDegree>().Length),
					AcademicTitle = (AcademicTitle)(Random.Shared.Next() % Enum.GetNames<AcademicTitle>().Length),
					Disciplines = ShuffleCollection(db.Disciplines.ToList(), Random.Shared.Next() % db.Disciplines.Count()),
					Works = works,
					Universities = universities,
					Dissertations = dissertations,
					Publications = new List<Publication>(),
					Posts = new List<Post>(),
					ProfessionalDevelopments = professionalDevelopments,
					ScienceProjects = scienceProjects,
					PublicActivities = publicActivities,
					Awards = awards
				};
				teacher.Publications.AddRange(articles);
				teacher.Publications.AddRange(monographies);
				teacher.Publications.AddRange(theses);
				teacher.Posts.AddRange(posts);
				await db.Teachers.AddAsync(teacher);
				await db.SaveChangesAsync();
			}
		}
		
		private List<T> ShuffleCollection<T>(List<T> list, int numberTake = 0)
		{
			var result = list.ToArray();
			Random.Shared.Shuffle(result);
			if (numberTake != 0)
				result = result.Take(numberTake).ToArray();
			return result.ToList();
		}
		private DateOnly GetDateMinMax(int min, int max)
		{
			var minDate = new DateTime(min, 1, 1);
			var maxDate = new DateTime(max, 1, 1);
			var minTicks = minDate.Ticks;
			var maxTicks = maxDate.Ticks;
			var baseTicks = maxTicks - minTicks;
			var toAdd = (long)(Random.Shared.NextDouble() * baseTicks);
			var newDate = new DateTime(minTicks + toAdd);
			return DateOnly.FromDateTime(newDate);
		}
	}
}
