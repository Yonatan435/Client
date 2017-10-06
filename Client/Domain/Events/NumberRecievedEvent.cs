using Utilities.Observer;

namespace Domain.Domain.Events
{
    public class NumberRecievedEvent : Event
    {
        public NumberRecievedEvent(int number)
        {
            Number = number;
        }
        public int Number { get; set; }
    }
}
