using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioShared.ViewModels.Response
{
    public record ResponseUser(Guid Id, string Email, string? FirstName, string? MiddleName, string? LastName, DateOnly? DateBirthday);
}
