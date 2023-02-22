using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebApplication1_feb16.DataAccess;
using WebApplication1_feb16.Models;

namespace WebApplication1_feb16.Repositories
{
    public class AuthRepository : IAuth
    {
        private readonly MoviedbContext moviesContext;
        private readonly IConfiguration configuration;

        public AuthRepository(MoviedbContext moviesContext, IConfiguration configuration)
        {
            this.moviesContext = moviesContext;
            this.configuration = configuration;
        }

        private string GetToken(User user)
        {
            // extra layer of protection using claims
            var tokenClaims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, configuration["Jwt:Register"]),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                new Claim("UserId", user.UserId.ToString() )

            };



            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:key"]));
            var signin = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(configuration["Jwt:Issuer"],
                configuration["jwt:Audience"],
                tokenClaims,
                expires: DateTime.Now.AddMinutes(24000),
                signingCredentials: signin);

            return new JwtSecurityTokenHandler().WriteToken(token);

        }

        public UserDTO LoginUser(UserDTO user)
        {
            try
            {
                if (user != null)
                {
                    var userExist = moviesContext.Users.Where(u => u.Email == user.Email && u.Password == user.Password).FirstOrDefault();

                    if (userExist != null)
                    {
                        user.Message = "Login Successful!";
                        user.Token = GetToken(userExist);
                        Console.WriteLine(GetToken(userExist));

                        return user;
                    }
                    else
                    {
                        throw new Exception("User doesn't exist");
                    }
                }
                else
                {
                    throw new Exception("Please enter user details!");
                }
            }
            catch (Exception loginException)
            {
                throw new Exception(loginException.Message);
            }
        }

        public UserDTO RegisterUser(UserDTO user)
        {
            throw new NotImplementedException();
        }
    }
}