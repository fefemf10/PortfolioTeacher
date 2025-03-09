using Portfolio.Application.Exceptions;
using Portfolio.Application.ViewModels.Request;
using Portfolio.Domain.Models;
using Portfolio.Domain.Services;
using Portfolio.Infrastructure;
using System.ComponentModel.DataAnnotations;

namespace Portfolio.Application.Services
{
    public class AdminService(ApplicationContext db) : IAdminService
    {
        public async Task AddTestUsers(List<Teacher> requestAddTeachers)
        {
            foreach (var requestAddTeacher in requestAddTeachers)
            {
                Faculty faculty = await db.Faculties.FindAsync(requestAddTeacher.FacultyId) ?? throw new NotFoundByIdException();
                Department? department = await db.Departments.FindAsync(requestAddTeacher.DepartmentId);
                List<Work> works = new()
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
                List<University> universities = new()
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
                await db.Awards.AddRangeAsync(awards);
                await db.PublicActivities.AddRangeAsync(publicActivities);
                await db.Publications.AddRangeAsync(publications);
                await db.Dissertations.AddRangeAsync(dissertations);
                await db.ScienceProjects.AddRangeAsync(scienceProjects);
                await db.ProfessionalDevelopments.AddRangeAsync(professionalDevelopments);
                await db.Works.AddRangeAsync(works);
                await db.Universities.AddRangeAsync(universities);
                Teacher teacher = new()
                {
                    Id = requestAddTeacher.Id,
                    Email = requestAddTeacher.Email,
                    Faculty = faculty,
                    Department = department,
                    LastName = requestAddTeacher.LastName,
                    FirstName = requestAddTeacher.FirstName,
                    MiddleName = requestAddTeacher.MiddleName,
                    DateBirthday = GetDateMinMax(1924, DateOnly.FromDateTime(DateTime.Now).Year - 18),
                    Post = (Post)(Random.Shared.Next() % Enum.GetNames<Post>().Length),
                    AcademicDegree = (AcademicDegree)(Random.Shared.Next() % Enum.GetNames<AcademicDegree>().Length),
                    AcademicTitle = (AcademicTitle)(Random.Shared.Next() % Enum.GetNames<AcademicTitle>().Length),
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
