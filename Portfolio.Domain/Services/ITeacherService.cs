using Portfolio.Domain.Models;

namespace Portfolio.Domain.Services
{
	public partial interface ITeacherService
	{
		Task<Guid> Add(Teacher teacher);
		Task Update(Teacher teacher);
		Task DeleteById(Guid id);
		Task<IEnumerable<Teacher>> GetAll();
		Task<IEnumerable<Teacher>> GetAllDependencies();
		Task<Teacher> GetById(Guid id);
		Task<Teacher> GetByIdWithDependencies(Guid id);
		Task AddInfo(Teacher teacher);
	}
}
