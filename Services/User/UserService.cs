using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Expension.Database.Dto.User;
using Expension.Database.Repositories.User;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Expension.Services.User
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;
        public UserService(IUserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }

        public List<UserFullDataDto> GetUsers()
        {
            return _userRepository.FindAll().Select(u => new UserFullDataDto
            {
                UserId = u.UserId,
                Email = u.Email,
                PasswordHash = u.PasswordHash,
                IsAdmin = u.IsAdmin
            }).ToList();
        }

        public UserFullDataDto GetUserByEmail(string email)
        {
            var user = _userRepository.FindSingleByCondition(u => u.Email == email);
            return user == null ? null : new UserFullDataDto(user.UserId, user.Email, user.PasswordHash, user.IsAdmin);
        }

        public UserTokenDto Authenticate(string password, UserFullDataDto userData)
        {
            if (!BCrypt.Net.BCrypt.Verify(password, userData.PasswordHash))
            {
                return null;
            }
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, userData.UserId.ToString()),
                    new Claim(ClaimTypes.Role, userData.IsAdmin ? "admin" : "user")
                }),
                Expires = System.DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["JWT:Key"])),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor));
            return new UserTokenDto(userData.UserId, userData.Email, userData.IsAdmin, token);
        }


        public bool AddUser(UserInputDataDto userData)
        {
            if (_userRepository.FindSingleByCondition(u => u.Email == userData.Email) != null)
            {
                return false;
            }

            var user = new Database.Models.User
            {
                Email = userData.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(userData.Password),
                IsAdmin = false
            };
            _userRepository.Create(user);
            _userRepository.Save();
            return true;
        }

        public bool DeleteUser(int id)
        {
            var user = _userRepository.FindSingleByCondition(u => u.UserId == id);
            if (user == null)
            {
                return false;
            }
            _userRepository.Delete(user);
            _userRepository.Save();
            return true;
        }
    }
}
