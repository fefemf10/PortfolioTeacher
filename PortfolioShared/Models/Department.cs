using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioShared.Models
{
	public class Department
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public Guid FacultyId { get; set; }
		public Faculty Faculty { get; set; }
		public List<Teacher> Teachers { get; set; } = new();
	}
}
