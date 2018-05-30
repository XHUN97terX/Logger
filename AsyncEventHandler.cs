using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Logging
{
    public delegate Task AsyncEventHandler<TEventArgs>(object o, TEventArgs args);
}
