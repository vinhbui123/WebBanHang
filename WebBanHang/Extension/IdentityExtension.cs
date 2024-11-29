using System.Security.Claims;

namespace WebBanHang.Extension
{
	public static class IdentityExtension
	{
		public static string GetSpecificClaim(this ClaimsPrincipal claimsPrincipal, String claimType)
		{
			var claim = claimsPrincipal.Claims.FirstOrDefault(x => x.Type == claimType);
			return (claim != null) ? claim.Value :String.Empty;
		}
	}
}
