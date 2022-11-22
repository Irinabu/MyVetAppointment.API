using Microsoft.IdentityModel.Tokens;
using MyVetAppointment.Business.Models.User;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MyVetAppointment.Business.Services.Implementations
{
    public class JwtService
    {
        private readonly JwtSecurityTokenHandler _jwtSecurityTokenHandler;
        private readonly SymmetricSecurityKey _securityKey;
        private readonly SigningCredentials _credentials;

        public JwtService()
        {
            _jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            _securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("MyVetAppointmentSecretKey"));
            _credentials = new SigningCredentials(_securityKey, SecurityAlgorithms.HmacSha256);
        }
        public string GenerateJwt(LoginRequest userInfo,string role)
        {

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                new Claim(ClaimsIdentity.DefaultNameClaimType, userInfo.Email),
                new Claim(ClaimsIdentity.DefaultRoleClaimType,role)
            };

            var token = new JwtSecurityToken
            (
                "MyVetAppointement",
                audience: "users",
                claims,
                DateTime.UtcNow.AddMilliseconds(-30),
                DateTime.UtcNow.AddDays(7),
                _credentials
            );

            return _jwtSecurityTokenHandler.WriteToken(token);
        }
        public string ValidateToken(string token)
        {
            if (token == null)
                return null;

            try
            {
                _jwtSecurityTokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = _securityKey,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                var userName = jwtToken.Claims.First(x => x.Type == ClaimsIdentity.DefaultNameClaimType).Value;

                return userName;
            }
            catch
            {
                return null;
            }
        }
    }
}
