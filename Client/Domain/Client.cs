using Domain.Domain.Events;
using Utilities.Observer;

namespace Domain.Domain
{
    public class Client : IServerCallback
    {
        IPublisher _publisher;
       
        public Client(IPublisher publisher)
        {
            _publisher = publisher;
        }
        
        public void ReceiveInt(int number)
        {
            _publisher.Publish(new NumberRecievedEvent(number));
        }
        public void ReceiveData(byte[] data)
        {
            _publisher.Publish(new DataRecievedEvent(data));
        }
    }
 }
