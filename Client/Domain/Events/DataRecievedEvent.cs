using Utilities.Observer;

namespace Domain.Domain.Events
{
    public class DataRecievedEvent : Event
    {
        public DataRecievedEvent(byte[] data)
        {
            Data = data;
        }
        public byte[] Data { get; set; }
    }
}
