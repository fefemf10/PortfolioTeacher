﻿using Microsoft.AspNetCore.Identity;

namespace PortfolioServer.Helpers
{
	public class Role : IdentityRole<Guid>
	{
		public Role() { Id = Guid.NewGuid(); }
		public Role(string roleName) : base(roleName) { Id = Guid.NewGuid(); }
	}
}
