using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using static System.String;

namespace Student_WebAdmin.Lib
{
    public static class SecurityManager
    {
        public class M_AccountSecurity
        {
            public string accessLogId { get; set; }
            public string accountId { get; set; }
            public string userId { get; set; }
            public string userName { get; set; }
            public string name { get; set; }
            public string avatar { get; set; }
            public string accessToken { get; set; }
            public bool stayLoggedIn { get; set; }
            public DateTimeOffset? cookiesIntervalTimeOut { get; set; }
            public List<string> role { get; set; }
            public string email { get; set; }   
        }
        private static IEnumerable<Claim> getUserClaims(M_AccountSecurity account)
        {
            List<Claim> claims = new List<Claim>()
            {
                new Claim("AccountId", account.accountId),
                new Claim("UserId", account.userId),
                new Claim(ClaimTypes.NameIdentifier, account.userName),
                new Claim(ClaimTypes.Name, account.name),
                new Claim("Avatar", account.avatar),
                new Claim("AccessToken", account.accessToken),
                new Claim("Email",account.email)
            };
            account.role?.ForEach((x) => { claims.Add(new Claim(ClaimTypes.Role, IsNullOrEmpty(x) ? "" : x)); });
            return claims;
        }
        public static async void SignIn(HttpContext httpContext, M_AccountSecurity account, string scheme)
        {
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(getUserClaims(account), scheme);
            ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
            await httpContext.SignInAsync(
                scheme: scheme,
                principal: claimsPrincipal,
                properties: new AuthenticationProperties
                {
                    //AllowRefresh = true,//Refreshing the authentication session should be allowed.
                    ExpiresUtc = account.cookiesIntervalTimeOut, //The time at which the authentication ticket expires. A value set here overrides the ExpireTimeSpan option of CookieAuthenticationOptions set with AddCookie
                    IsPersistent = account.stayLoggedIn,//Whether the authentication session is persisted across  multiple requests. When used withcookies, controls whether the cookie's lifetime is absolute (matching the lifetime of the authentication ticket) or session-based
                });
        }
        public static async void SignOut(HttpContext httpContext, string scheme)
        {
            if (httpContext.Request.Cookies.Count > 0)
            {
                httpContext.Response.Cookies.Delete("Authentication");
                //foreach (var cookie in httpContext.Request.Cookies.Keys)
                //    httpContext.Response.Cookies.Delete(cookie);
            }
            await httpContext.SignOutAsync(scheme);
            httpContext.Session.Clear();
        }
    }
}
