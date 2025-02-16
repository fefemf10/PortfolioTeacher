using Microsoft.EntityFrameworkCore;
using Portfolio.Domain.Models;

namespace Portfolio.Infrastructure.DbSetExtension
{
	public static class DbSetExtensions
	{
		public static IQueryable<T> GetByEmail<T>(this DbSet<T> users, string email) where T : User
		{
			return users.Where(x => x.Email == email);
		}
	}
}
