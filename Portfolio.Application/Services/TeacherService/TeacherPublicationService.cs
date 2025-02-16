using Portfolio.Domain.Models;
using Portfolio.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Application.Services.TeacherService
{
    public class TeacherPublicationService : ITeacherPublicationService
    {
        private readonly ApplicationContext db;
        public TeacherPublicationService(ApplicationContext db)
        {
            this.db = db;
        }

        public Task<Guid> Add(Guid id, Publication entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Guid id, Guid entityId)
        {
            throw new NotImplementedException();
        }

        public Task<Publication> Get(Guid id, Guid entityId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Guid>> GetAll(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task Update(Guid id, Publication entity)
        {
            throw new NotImplementedException();
        }
    }
}
