using Domain.Domain.Events;
using System.Windows.Input;
using Utilities.MVVM;
using Utilities.Observer;

namespace ui.Login
{
    public class LoginViewModel : ViewModelBase
    {
        public ICommand LoginCmd { get; set; }
        IPublisher _publisher;
        IServer _server;
        public LoginViewModel(IPublisher publisher, IServer server)
        {
            _server = server;
            _publisher = publisher;
            LoginCmd = new RelayCommand(() => Login());
        }

        private async void Login()
        {
            bool loggedIn = await _server.AuthenticateAsync(UserName, Password);
            if (loggedIn)
            {
                _publisher.Publish(new UserLoggedInChangedEvent(true));
                Message = string.Empty;
            }
            else
                Message = "Wrong credentials entered.";
        }
        private string _userName;

        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }
        private string _password;

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }
        private string _message;

        public string Message
        {
            get { return _message; }
            set
            {
                _message = value;
                NotifyPropertyChanged("Message");
            }
        }
    }
}
