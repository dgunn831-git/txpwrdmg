using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpusIntakeBlazorApps.Services
{
    public interface IMessageService
    {
        event Action<string> OnMessage;
        void SendMessage(string message);
    }
}
