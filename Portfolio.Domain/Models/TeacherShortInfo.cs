using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Domain.Models
{
    public class TeacherShortInfo
    {
        public IEnumerable<ShortItem> Works {get; set;}
        public IEnumerable<ShortItem> Universities {get; set;}
        public IEnumerable<ShortItem> ScienceProjects {get; set;}
        public IEnumerable<ShortItem> ProfessionalDevelopments {get; set;}
        public IEnumerable<ShortItem> Awards {get; set;}
    }
}
