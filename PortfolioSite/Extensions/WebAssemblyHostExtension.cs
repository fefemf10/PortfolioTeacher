using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.JSInterop;
using System.Globalization;

namespace PortfolioSite.Extensions
{
	public static class WebAssemblyHostExtension
	{
		public async static Task SetDefaultCulture(this WebAssemblyHost webAssemblyHost)
		{
			IJSRuntime jsInterop = webAssemblyHost.Services.GetRequiredService<IJSRuntime>();
			string result = await jsInterop.InvokeAsync<string>("blazorCulture.get");
			CultureInfo cultureInfo;
            if (result is null)
				cultureInfo = new CultureInfo("en-US");
			else
				cultureInfo = new CultureInfo(result);
			CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
			CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;
		}
	}
}
