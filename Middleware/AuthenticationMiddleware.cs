namespace UserManagementAPI.Middleware
{
    public class AuthenticationMiddleware
    {
        private readonly RequestDelegate _next;

        public AuthenticationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Path.StartsWithSegments("/swagger"))
            {
                await _next(context);
                return;
            }
            if (!context.Request.Headers.TryGetValue(
                "Authorization",
                out var token))
            {
                context.Response.StatusCode = 401;

                await context.Response.WriteAsync(
                    "Unauthorized: Token missing");

                return;
            }

            if (token != "Bearer my-secret-token")
            {
                context.Response.StatusCode = 401;

                await context.Response.WriteAsync(
                    "Unauthorized: Invalid token");

                return;
            }

            await _next(context);
        }
    }
}