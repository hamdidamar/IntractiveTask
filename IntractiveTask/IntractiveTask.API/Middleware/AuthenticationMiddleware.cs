using IntractiveTask.Business.Services;

namespace IntractiveTask.API.Middleware;

public class AuthenticationMiddleware
{
    private readonly RequestDelegate _next;

    public AuthenticationMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        if (httpContext.Request.Path.StartsWithSegments("/api/auth/login"))
        {
            await _next(httpContext);
            return;
        }

        var token = httpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
        if (string.IsNullOrEmpty(token))
        {
            httpContext.Response.StatusCode = StatusCodes.Status401Unauthorized;
            await httpContext.Response.WriteAsync("Unauthorized: No token provided.");
            return;
        }

        var jwtService = httpContext.RequestServices.GetRequiredService<JwtService>();
        try
        {
            var claimsPrincipal = jwtService.ValidateToken(token); 
            httpContext.User = claimsPrincipal;
        }
        catch (Exception)
        {
            httpContext.Response.StatusCode = StatusCodes.Status401Unauthorized;
            await httpContext.Response.WriteAsync("Unauthorized: Invalid token.");
            return;
        }

        await _next(httpContext);
    }
}

