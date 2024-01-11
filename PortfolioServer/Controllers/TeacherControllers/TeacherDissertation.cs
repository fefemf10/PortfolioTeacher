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
        public ActionResult<RequestDissertation[]> GetDissertation(Guid guid)
        {
            Teacher? teacher = db.Teachers.Include(x => x.Dissertations).SingleOrDefault(user => user.Id == guid);
            if (teacher is null)
                return BadRequest();
            RequestDissertation[] responseDissertations= Array.ConvertAll(teacher.Dissertations.ToArray(),
                dissertation => new RequestDissertation { Id = dissertation.Id, Name = dissertation.Name, YearProtection = dissertation.YearProtection });
            return Ok(responseDissertations);
        }
        [HttpGet("{guid:guid}/[action]/{dissertationId:guid}")]
        public ActionResult<RequestDissertation[]> GetDissertation(Guid guid, Guid dissertationId)
        {
            Teacher? teacher = db.Teachers.Include(x => x.Dissertations).SingleOrDefault(user => user.Id == guid);
            if (teacher is null)
                return BadRequest();
            Dissertation? dissertation = teacher.Dissertations.SingleOrDefault(dissertation => dissertation.Id == dissertationId);
            if (dissertation is null)
                return BadRequest();
            return Ok(new RequestDissertation { Id = dissertation.Id, Name = dissertation.Name, YearProtection = dissertation.YearProtection });
        }
        [HttpPost("{guid:guid}/[action]")]
        public ActionResult AddDissertation(Guid guid, [Required][FromBody] RequestDissertation requestDissertation)
        {
            Teacher? teacher = db.Teachers.Include(x => x.Dissertations).SingleOrDefault(user => user.Id == guid);
            if (teacher is null)
                return BadRequest();
            teacher.Dissertations.Add(new Dissertation {Id = requestDissertation.Id, Name = requestDissertation.Name, YearProtection = requestDissertation.YearProtection });
            db.SaveChanges();
            return Ok();
        }
        [HttpPut("{guid:guid}/[action]")]
        public ActionResult UpdateDissertation(Guid guid, [Required][FromBody] RequestDissertation requestDissertation)
        {
            Teacher? teacher = db.Teachers.Include(x => x.Dissertations).SingleOrDefault(user => user.Id == guid);
            if (teacher is null)
                return BadRequest();
            Dissertation? dissertation = teacher.Dissertations.SingleOrDefault(dissertation => dissertation.Id == requestDissertation.Id);
            if (dissertation is null)
                return BadRequest();
            dissertation.Name = requestDissertation.Name;
            dissertation.YearProtection = requestDissertation.YearProtection;
            db.SaveChanges();
            return Ok();
        }
        [HttpDelete("{guid:guid}/[action]/{dissertationId:guid}")]
        public ActionResult DeleteDissertation(Guid guid, Guid dissertationId)
        {
            Teacher? teacher = db.Teachers.Include(x => x.Dissertations).SingleOrDefault(user => user.Id == guid);
            if (teacher is null)
                return BadRequest();
            Dissertation? dissertation = teacher.Dissertations.SingleOrDefault(dissertation => dissertation.Id == dissertationId);
            if (dissertation is null)
                return BadRequest();
            teacher.Dissertations.Remove(dissertation);
            db.SaveChanges();
            return Ok();
        }
    }
}
