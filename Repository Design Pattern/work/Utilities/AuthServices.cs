using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using work.DbConext;
using work.Models;

namespace work.Utilities
{
    public class AuthServices
    {
        private readonly IConfiguration _configuration;
        private readonly ApplicationDbContext _context;
        public AuthServices(IConfiguration configuration, ApplicationDbContext context)
        {
            _configuration = configuration;
            _context = context;
        }

        public async Task<string> GenerateJwtToken()
        {
            // Generate JWT token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Issuer = _configuration["Jwt:Issuer"],
                Audience = _configuration["Jwt:Audience"]
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return tokenString;
        }

        public async Task<int> Register(Register model)
        {
            var hashedpassword = PasswordHasher(model.Password);
            model.Password = hashedpassword;
            _context.Registers.Add(model);
           return await _context.SaveChangesAsync();
        }

        public async Task<string> Login(string email, string password)
        {
            var user = await _context.Registers.FirstOrDefaultAsync(x => x.Email == email);
            if (user == null)
            {
                return "User With Email is Not Exists";

            }

            var is_user = VerifyPassword(password,user.Password);
            if (is_user)
            {
                var token = await GenerateJwtToken();
                return $"Token: {token}";
            }
            else
            {
                return "Incorrect Email or Password";
            }
        }
       

        public string PasswordHasher(string password)
        {
            var salt = BCrypt.Net.BCrypt.GenerateSalt(); // Generate a new salt
           
            return BCrypt.Net.BCrypt.HashPassword(password, salt);
        }

        public bool VerifyPassword(string password, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }

    }
}
