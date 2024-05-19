using Hotel.Core.Models.Common;

namespace Hotel.Core.Models
{
    public abstract class UserModel : Model
    {
        public string Password { get; private set; } = string.Empty;
        public string Login { get; private set; } = string.Empty;
        protected UserModel(Guid id, string password, string login) : base(id)
        {
            Password = password;
            Login = login;
        }
    }
}
