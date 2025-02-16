using Microsoft.EntityFrameworkCore;
using Portfolio.Application.Exceptions;
using Portfolio.Domain.Models;
using Portfolio.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Application.Services
{
    public abstract class BaseTeacherService
    {
        protected readonly ApplicationContext db;
        protected BaseTeacherService(ApplicationContext db)
        {
            this.db = db;
        }
        //protected async Task<Teacher> GetTeacherWithEntity(Guid id)
        //{
        //    Teacher? teacher = await db.Teachers.FindAsync(id) ?? throw new NotFoundByIdException();
        //    await db.Entry(teacher).Collection().LoadAsync();
        //    return teacher;
        //}
    }
}
