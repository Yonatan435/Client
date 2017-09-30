using Client.ServerService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Client: IServerCallback
    {
        List<int> _recievedNumbers;
        List<byte> _recievedBytes;
        public Client()
        {
            _recievedNumbers = new List<int>();
            _recievedBytes = new List<byte>();
        }
        public void ReceiveInt(int number)
        {
            _recievedNumbers.Add(number);
            Console.WriteLine("Recieved number: {0}", number);
        }
        public void ReceiveData(byte[] data)
        {
            _recievedBytes.AddRange(data);
            Console.WriteLine("Recieved data");
        }
    }
}
