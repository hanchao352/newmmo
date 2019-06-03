using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;
using Managers;

namespace Services
{
    class ChatService : Singleton<ChatService>
    {
        internal void SendChat(ChatManager.LocalChannel sendChannel, string content, int toId, string toName)
        {
            throw new NotImplementedException();
        }
    }
}
