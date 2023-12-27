using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PortfolioShared.Models;
using PortfolioShared.ViewModels.Request;
using System.ComponentModel.DataAnnotations;

namespace PortfolioServer.Controllers.TeacherControllers
{
    public partial class TeacherController
    {
        [HttpGet("{guid:guid}/[action]")]
        public ActionResult<RequestProfessionalDevelopment[]> GetProfessionalDevelopment(Guid guid)
        {
            Teacher? teacher = db.Teachers.Include(x => x.ProfessionalDevelopments).SingleOrDefault(user => user.Id == guid);
            if (teacher is null)
                return BadRequest();
            RequestProfessionalDevelopment[] responseProfessionalDevelopments = Array.ConvertAll(teacher.ProfessionalDevelopments.ToArray(),
                professionalDevelopment => new RequestProfessionalDevelopment { Id = professionalDevelopment.Id, Name = professionalDevelopment.Name, NameOrganization = professionalDevelopment.NameOrganization, NameDocument = professionalDevelopment.NameDocument, SeriaDocument = professionalDevelopment.SeriaDocument, NumberDocument = professionalDevelopment.NumberDocument, DateСompletion = professionalDevelopment.DateСompletion, ListeningTime = professionalDevelopment.ListeningTime });
            return Ok(responseProfessionalDevelopments);
        }
        [HttpGet("{guid:guid}/[action]/{professionalDevelopmentId:guid}")]
        public ActionResult<RequestProfessionalDevelopment[]> GetProfessionalDevelopment(Guid guid, Guid professionalDevelopmentId)
        {
            Teacher? teacher = db.Teachers.Include(x => x.ProfessionalDevelopments).SingleOrDefault(user => user.Id == guid);
            if (teacher is null)
                return BadRequest();
            ProfessionalDevelopment? professionalDevelopment = teacher.ProfessionalDevelopments.SingleOrDefault(professionalDevelopment => professionalDevelopment.Id == professionalDevelopmentId);
            if (professionalDevelopment is null)
                return BadRequest();
            return Ok(new RequestProfessionalDevelopment { Id = professionalDevelopment.Id, Name = professionalDevelopment.Name, NameOrganization = professionalDevelopment.NameOrganization, NameDocument = professionalDevelopment.NameDocument, SeriaDocument = professionalDevelopment.SeriaDocument, NumberDocument = professionalDevelopment.NumberDocument, DateСompletion = professionalDevelopment.DateСompletion, ListeningTime = professionalDevelopment.ListeningTime });
        }
        [HttpPost("{guid:guid}/[action]")]
        public ActionResult AddProfessionalDevelopment(Guid guid, [Required][FromBody] RequestProfessionalDevelopment requestProfessionalDevelopment)
        {
            Teacher? teacher = db.Teachers.Include(x => x.ProfessionalDevelopments).SingleOrDefault(user => user.Id == guid);
            if (teacher is null)
                return BadRequest();
            teacher.ProfessionalDevelopments.Add(new ProfessionalDevelopment { Id = requestProfessionalDevelopment.Id, Name = requestProfessionalDevelopment.Name, NameOrganization = requestProfessionalDevelopment.NameOrganization, NameDocument = requestProfessionalDevelopment.NameDocument, SeriaDocument = requestProfessionalDevelopment.SeriaDocument, NumberDocument = requestProfessionalDevelopment.NumberDocument, DateСompletion = requestProfessionalDevelopment.DateСompletion, ListeningTime = requestProfessionalDevelopment.ListeningTime });
            db.SaveChanges();
            return Ok();
        }
        [HttpPut("{guid:guid}/[action]")]
        public ActionResult UpdateProfessionalDevelopment(Guid guid, [Required][FromBody] RequestProfessionalDevelopment requestProfessionalDevelopment)
        {
            Teacher? teacher = db.Teachers.Include(x => x.ProfessionalDevelopments).SingleOrDefault(user => user.Id == guid);
            if (teacher is null)
                return BadRequest();
            ProfessionalDevelopment? professionalDevelopment = teacher.ProfessionalDevelopments.SingleOrDefault(professionalDevelopment => professionalDevelopment.Id == requestProfessionalDevelopment.Id);
            if (professionalDevelopment is null)
                return BadRequest();
            professionalDevelopment.Name = requestProfessionalDevelopment.Name;
            professionalDevelopment.NameOrganization = requestProfessionalDevelopment.NameOrganization;
            professionalDevelopment.NameDocument = requestProfessionalDevelopment.NameDocument;
            professionalDevelopment.SeriaDocument = requestProfessionalDevelopment.SeriaDocument;
            professionalDevelopment.NumberDocument = requestProfessionalDevelopment.NumberDocument;
            professionalDevelopment.DateСompletion = requestProfessionalDevelopment.DateСompletion;
            professionalDevelopment.ListeningTime = requestProfessionalDevelopment.ListeningTime;
            db.SaveChanges();
            return Ok();
        }
        [HttpDelete("{guid:guid}/[action]/{professionalDevelopmentId:guid}")]
        public ActionResult DeleteProfessionalDevelopment(Guid guid, Guid professionalDevelopmentId)
        {
            Teacher? teacher = db.Teachers.Include(x => x.ProfessionalDevelopments).SingleOrDefault(user => user.Id == guid);
            if (teacher is null)
                return BadRequest();
            ProfessionalDevelopment? professionalDevelopment = teacher.ProfessionalDevelopments.SingleOrDefault(professionalDevelopment => professionalDevelopment.Id == professionalDevelopmentId);
            if (professionalDevelopment is null)
                return BadRequest();
            teacher.ProfessionalDevelopments.Remove(professionalDevelopment);
            db.SaveChanges();
            return Ok();
        }
    }
}
