using PortfolioShared.Authorization;
using PortfolioShared.Models.Service;
using PortfolioShared.ViewModels.Request;
using PortfolioShared.ViewModels.Response;
using System.Net.Http;
using System.Net.Http.Json;
using static PortfolioSite.Pages.FetchData;
using System.Text.Json;

namespace PortfolioSite.Services
{
	public class AuthorzationAPI : IAuthorizationAPI
	{
		private readonly HttpClient httpClient;
		public AuthorzationAPI(HttpClient httpClient)
		{
			this.httpClient = httpClient;
		}

		public async Task<ResponseLogin> Login(RequestLogin requestLogin)
		{
			var result = await httpClient.PostAsJsonAsync("api/Auth/login", requestLogin);
			if (result.StatusCode == System.Net.HttpStatusCode.BadRequest) throw new Exception(await result.Content.ReadAsStringAsync());
			result.EnsureSuccessStatusCode();
			string content = await result.Content.ReadAsStringAsync();
			return JsonSerializer.Deserialize<ResponseLogin>(content);
		}

		public async Task Logout()
		{
			throw new NotImplementedException();
		}

		public async Task<ResponseRegistration> Register(RequestRegistration requestRegistration)
		{
			var result = await httpClient.PostAsJsonAsync("api/Auth/registration", requestRegistration);
			if (result.StatusCode == System.Net.HttpStatusCode.BadRequest) throw new Exception(await result.Content.ReadAsStringAsync());
			result.EnsureSuccessStatusCode();
			return new ResponseRegistration(Guid.NewGuid(), "", "", "");
		}

		public async Task<ResponseUser> GetUserInfo()
		{
			var result = await httpClient.GetFromJsonAsync<User>("api/Auth/User");
			return Task.CompletedTask;
		}
	}
}
