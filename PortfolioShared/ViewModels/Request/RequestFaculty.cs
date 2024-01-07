﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioShared.ViewModels.Request
{
	public record RequestFaculty([Required] Guid Id, [Required] string Name);
}
