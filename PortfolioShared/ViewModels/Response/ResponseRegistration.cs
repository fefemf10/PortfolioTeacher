using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioShared.ViewModels.Response
{
	public record ResponseRegistration(Guid Guid, string Email, string AccessToken, string RefreshToken);
}
