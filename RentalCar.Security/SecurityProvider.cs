using Microsoft.IdentityModel.Tokens;
using RentalCar.Application.Common.Interfaces.Authentication;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace RentalCar.Security
{
    public class SecurityProvider : ISecurityProvider
    {
        private readonly JwtSettings _jwtSettings;

        public SecurityProvider(JwtSettings jwtSettings)
        {
            _jwtSettings = jwtSettings;
        }
        public string GenerateToken(int userId, string firstname, string lastname, string role, IList<string> permissions)
        {
            string userIdStr = userId.ToString();
            var credentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret)), SecurityAlgorithms.HmacSha256);

            List<Claim> claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, userIdStr),
                new Claim(JwtRegisteredClaimNames.GivenName, firstname),
                new Claim(JwtRegisteredClaimNames.FamilyName, lastname),
                new Claim("userid", userIdStr),
                new Claim("platformrole", role)
            };

            foreach (string permission in permissions)
            {
                claims.Add(new Claim("permissions", permission));
            }

            var token = new JwtSecurityToken(claims: claims, signingCredentials: credentials, expires: DateTime.Now.AddMinutes(_jwtSettings.TTLMinutes));

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                UnicodeEncoding encoding = new UnicodeEncoding();
                StringBuilder builder = new StringBuilder();

                byte[] bytes = sha256.ComputeHash(encoding.GetBytes(password));

                foreach (var b in bytes)
                {
                    builder.AppendFormat("{0:x2}", b);
                }

                return builder.ToString().ToUpper();
            }
        }
    }
}
