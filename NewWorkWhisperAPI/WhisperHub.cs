using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace NewWorkWhisperAPI
{

    public class WhisperHub : Hub
    {
        public async Task SendWhisper(string whisperData)
        {
            // Broadcast the received whisperData to all connected clients
            await Clients.All.SendAsync("ReceiveWhisper", whisperData);
        }
    }
}



