using Domain.Domain;
using Domain.Domain.Events;
using System.ServiceModel;
using System.Windows;
using ui.Login;
using ui.User;
using Utilities.MVVM;
using Utilities.Observer;

namespace ui
{
    public class MainWindowViewModel : ViewModelBase
    {
        
        public MainWindowViewModel()
        
        {
            IPublisher publisher = new Publisher();
            InstanceContext site = new InstanceContext(new Client(publisher));
            ServerClient server = new ServerClient(site, "WSDualHttpBinding_IServer");
            
            var eventRegistration = publisher.Register<UserLoggedInChangedEvent>(onUserLoggedInChanged);
            //eventRegistration.Dispose();
            Login = new LoginViewModel(publisher, server);
            UserViewModel = new UserViewModel(publisher, server);
            
            LoginVisibility = Visibility.Visible;
            UserVisibility = Visibility.Collapsed;
        }

        private void onUserLoggedInChanged(UserLoggedInChangedEvent @event)
        {
            if (@event.LoggedIn)
                UserVisibility = Visibility.Visible;
            else
                LoginVisibility = Visibility.Visible;
        }
        
        private LoginViewModel _login;

        public LoginViewModel Login
        {
            get { return _login; }
            set { _login = value; }
        }
        private UserViewModel _userViewModel;

        public UserViewModel UserViewModel
        {
            get { return _userViewModel; }
            set { _userViewModel = value;}
        }
        private Visibility _userVisibility;

        public Visibility UserVisibility
        {
            get { return _userVisibility; }
            set
            {
                _userVisibility = value;
                if (UserVisibility == Visibility.Visible)
                    LoginVisibility = Visibility.Collapsed;
                NotifyPropertyChanged("UserVisibility");

            }
        }
        private Visibility _loginVisibility;

        public Visibility LoginVisibility
        {
            get { return _loginVisibility; }
            set
            {
                _loginVisibility = value;
                if (LoginVisibility == Visibility.Visible)
                    UserVisibility = Visibility.Collapsed;
                NotifyPropertyChanged("LoginVisibility");
            }
        }
    }
}
