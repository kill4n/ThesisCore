using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace Potentiostat.Hubs
{
    public class ImpedanceAnalyzerHub : Hub
    {
        public async Task SendAction(string Action)
        {
            await Clients.Others.SendAsync("RecieveAction", Action);
        }

        public async Task SendData(string frequency, string impedance)
        {
            await Clients.Others.SendAsync("RecieveData", frequency, impedance);
        }
    }
}
