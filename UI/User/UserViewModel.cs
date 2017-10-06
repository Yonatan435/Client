using Domain.Domain.Events;
using System.Windows.Input;
using Utilities.MVVM;
using Utilities.Observer;

namespace ui.User
{
    public class UserViewModel: ViewModelBase
    {
        public ICommand CheckCmd { get; set; }
        public ICommand StartCmd { get; set; }
        public ICommand StopCmd { get; set; }
        public ICommand LogoutCmd { get; set; }
        IPublisher _publisher;
        IServer _server;
        public UserViewModel(IPublisher publisher, IServer server)
        {
            _server = server;
            _publisher = publisher;
            
            StartCmd = new RelayCommand(() => Start());
            StopCmd = new RelayCommand(() => Stop());
            LogoutCmd = new RelayCommand(() => Logout());
            publisher.Register<NumberRecievedEvent>(onNumberRecieved);
            publisher.Register<DataRecievedEvent>(onDataRecieved);
        }

        private void onDataRecieved(DataRecievedEvent @event)
        {
            var str = System.Text.Encoding.Default.GetString(@event.Data);
            DataContent = str;
        }

        private void onNumberRecieved(NumberRecievedEvent @event)
        {
            TextContent = string.Format("Recieved Number: {0}", @event.Number);
        }

        private void Logout()
        {
            _server.Logout();
            _publisher.Publish(new UserLoggedInChangedEvent(false));
        }
        private void Start()
        {
            _server.StartDataTransfer();
        }
        private void Stop()
        {
            _server.StopDataTransfer();
        }
        
        private string _textContent;

        public string TextContent
        {
            get { return _textContent; }
            set
            {
                _textContent = value;
                NotifyPropertyChanged("TextContent");
            }
        }
        private string _dataContent;

        public string DataContent
        {
            get { return _dataContent; }
            set
            {
                _dataContent = value;
                NotifyPropertyChanged("DataContent");
            }
        }
    }
}
