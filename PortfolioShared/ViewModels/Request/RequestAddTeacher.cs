﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioShared.ViewModels.Request
{
	public class RequestAddTeacher
	{
		[Required]
		public Guid Id { get; set; }
		[Required]
		[EmailAddress]
		public string Email { get; set; }
		[Required]
		public string Role { get; set; }
		[Required]
		public Guid FacultyId { get; set; }
		public Guid? DepartmentId { get; set; }
	}
}
