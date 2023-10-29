using Microsoft.AspNetCore.Components;
using System.Globalization;

namespace PortfolioSite.Shared
{
	public partial class CultureSelector
	{
		//[Inject]
		//public NavigationManager NavManager { get; set; }
		//[Inject]
		//public ILocalStorageService localStorage {  get; set; }
		CultureInfo[] cultures = new[]
		{
			new CultureInfo("en-US"),
			new CultureInfo("ru-RU")
		};
		CultureInfo Culture
		{
			get => CultureInfo.CurrentCulture;
			set
			{
				if (CultureInfo.CurrentCulture != value)
				{
					//localStorage.SetItemAsStringAsync("BlazorCulture", value.Name);
					//NavManager.NavigateTo(NavManager.Uri, forceLoad: true);
				}
			}
		}
	}
}
