using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasiChat.Models
{
    public class ChatHub : Hub
    {
        public override async Task OnConnectedAsync()
        {
            await Clients.Caller.SendAsync("GetConnectionId", this.Context.ConnectionId);
        }
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);//ReceiveMessage =>clientteki js methodunun adıdır.user ve message ise methodun aldığı parametrelerdir.
        }
    }
}
