namespace WebAPIStrain.Middleware
{
    using Microsoft.AspNetCore.Http;
    using System.Net;
    using System.Text;
    using System.Threading.Tasks;

    public class SwaggerBasicAuthMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly string _username;
        private readonly string _password;

        public SwaggerBasicAuthMiddleware(RequestDelegate next, string username, string password)
        {
            _next = next;
            _username = username;
            _password = password;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Path.StartsWithSegments("/swagger"))
            {
                string authHeader = context.Request.Headers["Authorization"];

                if (authHeader != null && authHeader.StartsWith("Basic "))
                {
                    string encodedUsernamePassword = authHeader.Substring("Basic ".Length).Trim();
                    string usernamePassword = Encoding.UTF8.GetString(Convert.FromBase64String(encodedUsernamePassword));
                    var parts = usernamePassword.Split(':');

                    if (parts.Length == 2 && parts[0] == _username && parts[1] == _password)
                    {
                        await _next(context);
                        return;
                    }
                }

                context.Response.Headers["WWW-Authenticate"] = "Basic";
                context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                await context.Response.WriteAsync("Unauthorized");
            }
            else
            {
                await _next(context);
            }
        }
    }
}
