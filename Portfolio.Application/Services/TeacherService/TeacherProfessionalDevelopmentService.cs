﻿using Portfolio.Domain.Models;
using Portfolio.Domain.Services;

namespace Portfolio.Application.Services.TeacherService
{
    public class TeacherProfessionalDevelopmentService : ITeacherProfessionalDevelopmentService
    {
        private readonly ApplicationContext db;
        public TeacherProfessionalDevelopmentService(ApplicationContext db)
        {
            this.db = db;
        }

        public Task<Guid> Add(Guid id, ProfessionalDevelopment entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Guid id, Guid entityId)
        {
            throw new NotImplementedException();
        }

        public Task<ProfessionalDevelopment> Get(Guid id, Guid entityId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Guid>> GetAll(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task Update(Guid id, ProfessionalDevelopment entity)
        {
            throw new NotImplementedException();
        }
    }
}
