using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioShared.ViewModels.Response
{
	public record ResponseWork(int Id, string Name, string Post, DateOnly BeginTimeWork, DateOnly? EndTimeOnly);
}
