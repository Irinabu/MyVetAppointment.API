using MyVetAppointment.Business.Services.Implementations;
using MyVetAppointment.Data.Repositories;

namespace MyVetAppointment.API.Middlewares
{
    public class TokenMiddleware
    {
        private readonly RequestDelegate _next;


        public TokenMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, IUserRepository userRepository,JwtService tokenHandler)
        {
            var token = context.Request.Headers["Authorization"].ToString().Replace("Bearer ", string.Empty);
            if (token != null && token != "")
            { 
                var email = tokenHandler.ValidateToken(token);
                if (email == null)
                {
                    context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    return;
                }
                var user = await userRepository.GetFirstAsync(x => x.Email == email);
                if (user == null)
                {
                    context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    return;
                }
                context.Items["User"] = user;
            }
            await _next(context);
        }
    }
}
