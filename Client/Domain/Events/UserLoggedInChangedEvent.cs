using Utilities.Observer;

namespace Domain.Domain.Events
{
    public class UserLoggedInChangedEvent : Event
    {
        public UserLoggedInChangedEvent(bool loggedIn)
        {
            LoggedIn = loggedIn;
        }

        public bool LoggedIn { get; set; }
    }
}
