using Microsoft.AspNetCore.SignalR;

namespace signalr_simple_application_project.Hubs
{
    public class UserHub : Hub
    {
        public static int TotalViews { get; private set; } = 0;

        public static int TotalUsers { get; set; } = 0;

        public override Task OnConnectedAsync()
        {
            TotalUsers++;
            Clients.All.SendAsync("updateTotalUsers", TotalUsers).GetAwaiter().GetResult();
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception? exception)
        {
            TotalUsers--;
            Clients.All.SendAsync("updateTotalUsers", TotalUsers).GetAwaiter().GetResult();
            return base.OnDisconnectedAsync(exception);
        }


        public async Task NewWindowLoaded()
        {
            TotalViews++;

            // Sending an update to all connected clients
            await Clients.All.SendAsync("updateTotalViews", TotalViews);
        }
    }
}
