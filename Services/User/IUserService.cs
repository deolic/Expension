using System.Collections.Generic;
using Expension.Database.Dto.User;

namespace Expension.Services.User
{
    public interface IUserService
    {
        List<UserFullDataDto> GetUsers();
        UserFullDataDto GetUserByEmail(string email);
        UserTokenDto Authenticate(string password, UserFullDataDto userData);
        bool AddUser(UserInputDataDto userData);
        bool DeleteUser(int id);
    }
}
