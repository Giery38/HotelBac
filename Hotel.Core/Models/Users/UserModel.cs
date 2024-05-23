using Hotel.Core.Models.Common;

namespace Hotel.Core.Models
{
    public abstract class UserModel : Model
    {
        public string Name { get; private set; } = string.Empty;
        public string BirthDate { get; private set; } = string.Empty;
        public string Gender { get; private set; } = string.Empty;
        public int Rating { get; private set; } = 0;
      //  public List<GuestFeedbackEntity> GuestFeedbacks { get; set; } = [];
    }
}
