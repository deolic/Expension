namespace Expension.Database.Dto.User
{
    public class UserFullDataDto
    {
        public UserFullDataDto(int id, string email, string passwordHash, bool isAdmin)
        {
            UserId = id;
            Email = email;
            PasswordHash = passwordHash;
            IsAdmin = isAdmin;
        }

        public UserFullDataDto()
        {
        }

        public int UserId { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public bool IsAdmin { get; set; }
    }
}
