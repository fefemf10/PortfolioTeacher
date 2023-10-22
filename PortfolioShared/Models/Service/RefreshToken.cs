namespace PortfolioShared.Models.Service
{
	public class RefreshToken
	{
		public string Token { get; set; }
		public DateTimeOffset ExpiresOn { get; set; }
		public bool isExpired => DateTimeOffset.UtcNow >= ExpiresOn;
		public DateTimeOffset CreatedOn { get; set; }
		public DateTimeOffset? RevokedOn { get; set; }
		public bool isActive => RevokedOn == null && !isExpired;
	}
}
