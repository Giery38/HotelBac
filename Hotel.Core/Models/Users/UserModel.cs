using Hotel.Core.Models.Base;

namespace Hotel.Core.Models.Users
{
    public abstract class UserModel : BaseModel
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
