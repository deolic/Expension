namespace Expension.Database.Dto.User
{
    public class UserInputDataDto
    {
        public UserInputDataDto(string email, string password)
        {
            Email = email;
            Password = password;
        }

        public UserInputDataDto()
        {
        }

        public string Email { get; set; }
        public string Password { get; set; }
    }
}
