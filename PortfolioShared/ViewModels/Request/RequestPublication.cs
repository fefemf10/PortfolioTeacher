using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioShared.ViewModels.Request
{
	public class RequestPublication
	{
		[Required]
		public Guid Id { get; set; }
		[Required]
		public required string Name { get; set; }
		[Required]
		public string? Form { get; set; }
		[Required]
		public string? OutputData { get; set; }
		[Required]
		public uint Size { get; set; }
		[Required]
		public string? CoAuthor { get; set; }
	}
}
