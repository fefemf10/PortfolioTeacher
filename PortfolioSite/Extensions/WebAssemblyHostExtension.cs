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
			CultureInfo cultureInfo;
			if (result is null)
				cultureInfo = new CultureInfo("ru-RU");
			else
				cultureInfo = new CultureInfo(result);
			CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
			CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;
		}
	}
}
