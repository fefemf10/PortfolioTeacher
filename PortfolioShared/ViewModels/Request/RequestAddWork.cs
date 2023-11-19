using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioShared.ViewModels.Request
{
	public record RequestAddWork(string Name, string Post, DateOnly BeginTimeWork, DateOnly? EndTimeOnly);
}
