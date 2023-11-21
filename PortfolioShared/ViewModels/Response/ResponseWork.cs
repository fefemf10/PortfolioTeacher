using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioShared.ViewModels.Response
{
	public class ResponseWork
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Post { get; set; }
		public DateOnly BeginTimeWork { get; set; } = DateOnly.FromDateTime(DateTimeOffset.Now.DateTime);
		public DateOnly? EndTimeOnly { get; set; }
	}
}
