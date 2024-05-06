using Hotel.Core.Models.Common;

namespace Hotel.Core.Models.Users
{
    public abstract class UserModel : Model
    {
        public string Password { get; private set; } = string.Empty;
        public string Login { get; private set; } = string.Empty;
        protected UserModel(string password, string login)
        {
            Password = password;
            Login = login;
        }
    }
}
