namespace Expension.Database.Dto.User
{
    public class UserTokenDto
    {
        public UserTokenDto(int userId, string email, bool isAdmin, string token)
        {
            UserId = userId;
            Email = email;
            IsAdmin = isAdmin;
            Token = token;
        }

        public UserTokenDto()
        {
        }

        public int UserId { get; set; }
        public string Email { get; set; }
        public bool IsAdmin { get; set; }
        public string Token { get; set; }
    }
}
