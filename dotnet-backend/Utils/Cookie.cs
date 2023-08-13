using Microsoft.AspNetCore.Http;

namespace dotnet_backend.Utils
{
    public static class Cookie
    {
        public static CookieOptions CreateOptions(string domain)
        {
            return new CookieOptions
            {
                Expires = DateTimeOffset.Now.AddDays(1),
                Domain = domain,
                Path = "/",
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.Strict
            };
        }
    }
}
