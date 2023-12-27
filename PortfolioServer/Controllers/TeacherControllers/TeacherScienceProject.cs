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
        public ActionResult<RequestScienceProject[]> GetScienceProject(Guid guid)
        {
            Teacher? teacher = db.Teachers.Include(x => x.ScienceProjects).SingleOrDefault(user => user.Id == guid);
            if (teacher is null)
                return BadRequest();
            RequestScienceProject[] responseScienceProjects = Array.ConvertAll(teacher.ScienceProjects.ToArray(),
                scienceProject => new RequestScienceProject { Id = scienceProject.Id, Name = scienceProject.Name, BeginTimeWork = scienceProject.BeginTimeWork, EndTimeWork = scienceProject.EndTimeWork, Director = scienceProject.Director });
            return Ok(responseScienceProjects);
        }
        [HttpGet("{guid:guid}/[action]/{scienceProjectId:guid}")]
        public ActionResult<RequestScienceProject[]> GetScienceProject(Guid guid, Guid scienceProjectId)
        {
            Teacher? teacher = db.Teachers.Include(x => x.ScienceProjects).SingleOrDefault(user => user.Id == guid);
            if (teacher is null)
                return BadRequest();
            ScienceProject? scienceProject = teacher.ScienceProjects.SingleOrDefault(scienceProject => scienceProject.Id == scienceProjectId);
            if (scienceProject is null)
                return BadRequest();
            return Ok(new RequestScienceProject { Id = scienceProject.Id, Name = scienceProject.Name, BeginTimeWork = scienceProject.BeginTimeWork, EndTimeWork = scienceProject.EndTimeWork, Director = scienceProject.Director });
        }
        [HttpPost("{guid:guid}/[action]")]
        public ActionResult AddScienceProject(Guid guid, [Required][FromBody] RequestScienceProject requestScienceProject)
        {
            Teacher? teacher = db.Teachers.Include(x => x.ScienceProjects).SingleOrDefault(user => user.Id == guid);
            if (teacher is null)
                return BadRequest();
            teacher.ScienceProjects.Add(new ScienceProject { Id = requestScienceProject.Id, Name = requestScienceProject.Name, BeginTimeWork = requestScienceProject.BeginTimeWork, EndTimeWork = requestScienceProject.EndTimeWork, Director = requestScienceProject.Director });
            db.SaveChanges();
            return Ok();
        }
        [HttpPut("{guid:guid}/[action]")]
        public ActionResult UpdateScienceProject(Guid guid, [Required][FromBody] RequestScienceProject requestScienceProject)
        {
            Teacher? teacher = db.Teachers.Include(x => x.ScienceProjects).SingleOrDefault(user => user.Id == guid);
            if (teacher is null)
                return BadRequest();
            ScienceProject? scienceProject = teacher.ScienceProjects.SingleOrDefault(scienceProject => scienceProject.Id == requestScienceProject.Id);
            if (scienceProject is null)
                return BadRequest();
            scienceProject.Name = requestScienceProject.Name;
            scienceProject.BeginTimeWork = requestScienceProject.BeginTimeWork;
            scienceProject.EndTimeWork = requestScienceProject.EndTimeWork;
            scienceProject.Director = requestScienceProject.Director;
            db.SaveChanges();
            return Ok();
        }
        [HttpDelete("{guid:guid}/[action]/{scienceProjectId:guid}")]
        public ActionResult DeleteScienceProject(Guid guid, Guid scienceProjectId)
        {
            Teacher? teacher = db.Teachers.Include(x => x.ScienceProjects).SingleOrDefault(user => user.Id == guid);
            if (teacher is null)
                return BadRequest();
            ScienceProject? scienceProject = teacher.ScienceProjects.SingleOrDefault(scienceProject => scienceProject.Id == scienceProjectId);
            if (scienceProject is null)
                return BadRequest();
            teacher.ScienceProjects.Remove(scienceProject);
            db.SaveChanges();
            return Ok();
        }
    }
}
