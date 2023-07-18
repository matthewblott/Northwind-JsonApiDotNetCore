using System.Security.Claims;

namespace Northwind.Web.Services;

public interface ITokenService
{
  string GenerateAccessToken(IEnumerable<Claim> claims);
  string GenerateRefreshToken();
  ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
}