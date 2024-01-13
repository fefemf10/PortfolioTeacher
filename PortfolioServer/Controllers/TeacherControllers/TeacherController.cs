using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PortfolioShared.Models;
using PortfolioShared.ViewModels.Request;
using PortfolioShared.ViewModels.Response;
using System.ComponentModel.DataAnnotations;

namespace PortfolioServer.Controllers.TeacherControllers
{
	[Authorize]
	[Route("[controller]")]
	[ApiController]
	public partial class TeacherController : ControllerBase
	{
		private readonly ApplicationContext db;
		public TeacherController(ApplicationContext db)
		{
			this.db = db;
		}
		[HttpGet("{guid:guid}/[action]")]
		public ActionResult<ResponseTeacher> GetInfo(Guid guid)
		{
			Teacher? teacher = db.Teachers.Include(x => x.Faculty).Include(x => x.Department).Single(x => x.Id == guid);
			if (teacher is null)
				return BadRequest();
			return Ok(new ResponseTeacher(teacher.Id, teacher.Email, teacher.FirstName, teacher.MiddleName, teacher.LastName, teacher.DateBirthday, teacher.Post, teacher.AcademicDegree, teacher.AcademicTitle, new RequestFaculty(teacher.Faculty.Id, teacher.Faculty.Name), (teacher.Department is not null) ? new RequestDepartment(teacher.Department.Id, teacher.Department.Name) : null, (uint)teacher.Publications.Count));
		}
		[HttpPut("{guid:guid}/[action]")]
		public ActionResult AddInfo(Guid guid, [Required][FromBody] RequestTeacher requestTeacher)
		{
			Teacher? teacher = db.Teachers.Find(guid);
			if (teacher is null)
				return BadRequest();
			Department? department;
			if (requestTeacher.DepartmentId is not null)
			{
				department = db.Departments.Find(requestTeacher.DepartmentId);
				if (department is null)
					return BadRequest();
				else if (department is not null && department.FacultyId != requestTeacher.FacultyId)
					return BadRequest();
			}
			teacher.Email = requestTeacher.Email;
			teacher.FirstName = requestTeacher.FirstName;
			teacher.MiddleName = requestTeacher.MiddleName;
			teacher.LastName = requestTeacher.LastName;
			teacher.DateBirthday = requestTeacher.DateBirthday;
			teacher.Post = requestTeacher.Post;
			teacher.AcademicDegree = requestTeacher.AcademicDegree;
			teacher.AcademicTitle = requestTeacher.AcademicTitle;
			teacher.FacultyId = requestTeacher.FacultyId;
			teacher.DepartmentId = requestTeacher.DepartmentId;
			db.SaveChanges();
			return Ok();
		}
		[HttpPost("[action]")]
		public ActionResult AddTeacher([Required][FromBody] RequestAddTeacher requestAddTeacher)
		{
			Faculty? faculty = db.Faculties.Find(requestAddTeacher.FacultyId);
			if (faculty is null)
				return BadRequest();
			Department? department = db.Departments.Find(requestAddTeacher.DepartmentId);
			if (department is not null)
				if (department.FacultyId != faculty.Id)
					return BadRequest();
			Teacher teacher = new() { Id = requestAddTeacher.Id, Email = requestAddTeacher.Email, Faculty = faculty, Department = department };
			db.Teachers.Add(teacher);
			db.SaveChanges();
			return Ok();
		}
        [HttpPost("[action]")]
        public ActionResult AddTestTeacher([Required][FromBody] List<RequestAddTeacher> requestAddTeachers)
        {
            string[] fio = System.IO.File.ReadAllLines("SeedData/FIO.txt").ToArray();
            string?[] academicDegree = { null, "Кандидат наук", "Доктор наук" };
            string?[] academicTitle = { null, "Доцент", "Профессор" };
            string?[] post = { null, "Ассистент", "Преподаватель", "Старший преподаватель", "Лаборант", "Инженер" };
            foreach (var requestAddTeacher in requestAddTeachers)
            {
                Faculty? faculty = db.Faculties.Find(requestAddTeacher.FacultyId);
                Department? department = db.Departments.Find(requestAddTeacher.DepartmentId);
                var name = GetName(fio[Random.Shared.Next() % fio.Length]);
                List<Work> works = new List<Work>
                {
                    new Work
                    {
                        Name = "Работа 1",
                        Post = "Должность 1",
                        BeginTimeWork = GetDateMinMax(1980, 2024),
                    },
                    new Work
                    {
                        Name = "Работа 2",
                        Post = "Должность 2",
                        BeginTimeWork = GetDateMinMax(1980, 2024),
                    }
                };
                List<University> universities = new List<University>
                {
                    new University
                    {
                        Name = "Университет 1",
                        Qualification = "Квалификация 1",
                        Specialization = "Специализация 1",
                        YearGraduation = GetDateMinMax(1980, 2024).Year,
                    },
                    new University
                    {
                        Name = "Университет 2",
                        Qualification = "Квалификация 2",
                        Specialization = "Специализация 2",
                        YearGraduation = GetDateMinMax(1980, 2024).Year,
                    },
                    new University
                    {
                        Name = "Университет 3",
                        Qualification = "Квалификация 3",
                        Specialization = "Специализация 3",
                        YearGraduation = GetDateMinMax(1980, 2024).Year,
                    },
                };
                List<ProfessionalDevelopment> professionalDevelopments = new()
                {
                    new ProfessionalDevelopment()
                    {
                        Name = "Название 1",
                        NameDocument = "Название документа 1",
                        NameOrganization = "Организация",
                        ListeningTime = Random.Shared.Next() % 20,
                        DateСompletion = GetDateMinMax(2000, 2024),
                        NumberDocument = Random.Shared.Next().ToString(),
                        SeriaDocument = Random.Shared.Next().ToString(),
                    },
                    new ProfessionalDevelopment()
                    {
                        Name = "Название 1",
                        NameDocument = "Название документа 1",
                        NameOrganization = "Организация",
                        ListeningTime = Random.Shared.Next() % 20,
                        DateСompletion = GetDateMinMax(2000, 2024),
                        NumberDocument = Random.Shared.Next().ToString(),
                        SeriaDocument = Random.Shared.Next().ToString(),
                    }
                };
                List<ScienceProject> scienceProjects = new()
                {
                    new ScienceProject()
                    {
                        Name = "Научный проект 1",
                        Director = Random.Shared.Next() % 2 == 0,
                        BeginTimeWork = GetDateMinMax(2000, 2024),
                    },
                    new ScienceProject()
                    {
                        Name = "Научный проект 2",
                        Director = Random.Shared.Next() % 2 == 0,
                        BeginTimeWork = GetDateMinMax(2000, 2024),
                    }
                };
                List<Dissertation> dissertations = new()
                {
                    new Dissertation()
                    {
                        Name = "Диссертация 1",
                        YearProtection = GetDateMinMax(2000, 2024)
                    },
                    new Dissertation()
                    {
                        Name = "Диссертация 2",
                        YearProtection = GetDateMinMax(2000, 2024)
                    }
                };
                List<Publication> publications = new()
                {
                    new Publication()
                    {
                        Name = "Публикация 1",
                        Form = "Форма 1",
                        OutputData = "Выходные данные 1",
                        Size = (uint)Random.Shared.Next() % 500,
                        CoAuthor = "Соавтор 1"
                    },
                    new Publication()
                    {
                        Name = "Публикация 2",
                        Form = "Форма 2",
                        OutputData = "Выходные данные 2",
                        Size = (uint)Random.Shared.Next() % 500,
                        CoAuthor = "Соавтор 2"
                    }
                };
                List<PublicActivity> publicActivities = new()
                {
                    new PublicActivity()
                    {
                        Name = "Общественный проект 1",
                    },
                    new PublicActivity()
                    {
                        Name = "Общественный проект 2",
                    }
                };
                List<Award> awards = new()
                {
                    new Award()
                    {
                        Name = "Награда 1",
                        NameOrganization = "Организация 1",
                        DateAward = GetDateMinMax(1980, 2024)
                    },
                    new Award()
                    {
                        Name = "Награда 2",
                        NameOrganization = "Организация 2",
                        DateAward = GetDateMinMax(1980, 2024)
                    },
                    new Award()
                    {
                        Name = "Награда 3",
                        NameOrganization = "Организация 3",
                        DateAward = GetDateMinMax(1980, 2024)
                    }
                };
                db.Awards.AddRange(awards);
                db.PublicActivities.AddRange(publicActivities);
                db.Publications.AddRange(publications);
                db.Dissertations.AddRange(dissertations);
                db.ScienceProjects.AddRange(scienceProjects);
                db.ProfessionalDevelopments.AddRange(professionalDevelopments);
                db.Works.AddRange(works);
                db.Universities.AddRange(universities);
                Teacher teacher = new()
                {
                    Id = requestAddTeacher.Id,
                    Email = requestAddTeacher.Email,
                    Faculty = faculty,
                    Department = department,
                    LastName = name.Item1,
                    FirstName = name.Item2,
                    MiddleName = name.Item3,
                    DateBirthday = GetDateMinMax(1924, 2024),
                    Post = post[Random.Shared.Next() % post.Length],
                    AcademicDegree = academicDegree[Random.Shared.Next() % academicDegree.Length],
                    AcademicTitle = academicTitle[Random.Shared.Next() % academicTitle.Length],
                    Disciplines = ShuffleCollection(db.Disciplines.ToList(), Random.Shared.Next() % db.Disciplines.Count()),
                    Works = works,
                    Universities = universities,
                    ProfessionalDevelopments = professionalDevelopments,
                    ScienceProjects = scienceProjects,
                    Dissertations = dissertations,
                    Publications = publications,
                    PublicActivities = publicActivities,
                    Awards = awards
                };
                db.Teachers.Add(teacher);
                db.SaveChanges();
            }
            return Ok();
        }
        private (string, string, string) GetName(string value)
		{
			var splited = value.Split(' ');
			return (splited[0], splited[1], splited[2]);
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
