using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities.Observer
{
    public class Disposer : IDisposable
    {
        public Disposer(Action action)
        {
            Action = action;
        }
        public void Dispose()
        {
            Action.Invoke();
        }
        public Action Action { get; private set; }
    }
}
