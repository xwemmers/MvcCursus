using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCursus.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string name, string message)
        {
            // Sla eventueel de berichten in de DB
            await Clients.Others.SendAsync("NewMessage", name, message);
        }

        public async Task Login(string name)
        {
            await Clients.All.SendAsync("NewLogin", name);
        }
    }
}
