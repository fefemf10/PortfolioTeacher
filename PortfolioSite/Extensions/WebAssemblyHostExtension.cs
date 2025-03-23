using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using System.Globalization;

namespace PortfolioSite.Extensions
{
	public static class WebAssemblyHostExtension
	{
		public async static Task SetDefaultCulture(this WebAssemblyHost webAssemblyHost)
		{
			ILocalStorageService localStorage = webAssemblyHost.Services.GetRequiredService<ILocalStorageService>();
			string result = await localStorage.GetItemAsStringAsync("BlazorCulture");
			CultureInfo cultureInfo = new CultureInfo(result ?? "ru_RU");
			CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
			CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;
		}
	}
}
