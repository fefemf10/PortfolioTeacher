using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioShared.Models
{
	public class Faculty
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public List<Department> Departments { get; set; } = new();
	}
}
