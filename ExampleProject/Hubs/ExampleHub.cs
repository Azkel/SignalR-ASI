using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

namespace ExampleProject.Hubs
{
    public class ExampleHub : Hub
    {
        ///
        public override async Task OnConnectedAsync()
        {
            // Jeżeli dołaczył na kanał, wyślij do wszystkich informację, że dołączył.
            await Clients.All.SendAsync("SendToClient", $"{Context.ConnectionId} joined");
        }

        public Task SendToServer(string message)
        {
            // Wyślij wiadomość od użytkownika.
            return Clients.All.SendAsync("SendToClient", $"{Context.ConnectionId}: {message}");
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            // Jeżeli wyszedł z kanału, wyślij do wszystkich informację, że wyszedł.
            await Clients.All.SendAsync("SendToClient", $"{Context.ConnectionId} left.");
        }
    }
}


