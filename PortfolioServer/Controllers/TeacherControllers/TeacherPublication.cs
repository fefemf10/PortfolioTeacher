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
        public ActionResult<RequestPublication[]> GetPublication(Guid guid)
        {
            Teacher? teacher = db.Teachers.Include(x => x.Publications).SingleOrDefault(user => user.Id == guid);
            if (teacher is null)
                return BadRequest();
            RequestPublication[] responsePublications = Array.ConvertAll(teacher.Publications.ToArray(),
                publication => new RequestPublication { Id = publication.Id, Name = publication.Name, Form = publication.Form, OutputData = publication.OutputData, Size = publication.Size, CoAuthor = publication.CoAuthor });
            return Ok(responsePublications);
        }
        [HttpGet("{guid:guid}/[action]/{publicationId:guid}")]
        public ActionResult<RequestPublication[]> GetPublication(Guid guid, Guid publicationId)
        {
            Teacher? teacher = db.Teachers.Include(x => x.Publications).SingleOrDefault(user => user.Id == guid);
            if (teacher is null)
                return BadRequest();
            Publication? publication = teacher.Publications.SingleOrDefault(publication => publication.Id == publicationId);
            if (publication is null)
                return BadRequest();
            return Ok(new RequestPublication { Id = publication.Id, Name = publication.Name, Form = publication.Form, OutputData = publication.OutputData, Size = publication.Size, CoAuthor = publication.CoAuthor });
        }
        [HttpPost("{guid:guid}/[action]")]
        public ActionResult AddPublication(Guid guid, [Required][FromBody] RequestPublication requestPublication)
        {
            Teacher? teacher = db.Teachers.Include(x => x.Publications).SingleOrDefault(user => user.Id == guid);
            if (teacher is null)
                return BadRequest();
            teacher.Publications.Add(new Publication { Id = requestPublication.Id, Name = requestPublication.Name, Form = requestPublication.Form, OutputData = requestPublication.OutputData, Size = requestPublication.Size, CoAuthor = requestPublication.CoAuthor });
            db.SaveChanges();
            return Ok();
        }
        [HttpPut("{guid:guid}/[action]")]
        public ActionResult UpdatePublication(Guid guid, [Required][FromBody] RequestPublication requestPublication)
        {
            Teacher? teacher = db.Teachers.Include(x => x.Publications).SingleOrDefault(user => user.Id == guid);
            if (teacher is null)
                return BadRequest();
            Publication? publication = teacher.Publications.SingleOrDefault(publication => publication.Id == requestPublication.Id);
            if (publication is null)
                return BadRequest();
            publication.Name = requestPublication.Name;
            publication.Form = requestPublication.Form;
            publication.OutputData = requestPublication.OutputData;
            publication.Size = requestPublication.Size;
            publication.CoAuthor = requestPublication.CoAuthor;
            db.SaveChanges();
            return Ok();
        }
        [HttpDelete("{guid:guid}/[action]/{publicationId:guid}")]
        public ActionResult DeletePublication(Guid guid, Guid publicationId)
        {
            Teacher? teacher = db.Teachers.Include(x => x.Publications).SingleOrDefault(user => user.Id == guid);
            if (teacher is null)
                return BadRequest();
            Publication? publication = teacher.Publications.SingleOrDefault(publication => publication.Id == publicationId);
            if (publication is null)
                return BadRequest();
            teacher.Publications.Remove(publication);
            db.SaveChanges();
            return Ok();
        }
    }
}
