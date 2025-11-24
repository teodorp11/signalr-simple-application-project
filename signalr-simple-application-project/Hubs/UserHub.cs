using Microsoft.AspNetCore.SignalR;

namespace signalr_simple_application_project.Hubs
{
    public class UserHub : Hub
    {
        public static int TotalViews { get; private set; } = 0;

        public async Task NewWindowLoaded()
        {
            TotalViews++;

            // Sending an update to all connected clients
            await Clients.All.SendAsync("updateTotalViews", TotalViews);
        }
    }
}
