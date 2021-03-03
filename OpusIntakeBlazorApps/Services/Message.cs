using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpusIntakeBlazorApps.Services
{
    public class MessageService : IMessageService
    {
        public event Action<string> OnMessage;

        public void SendMessage(string message)
        {
            OnMessage?.Invoke(message);
        }
    }
}
