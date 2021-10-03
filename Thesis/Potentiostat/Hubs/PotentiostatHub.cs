using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Potentiostat.Hubs
{
    public class PotentiostatHub : Hub
    {
        public async Task SendParameters(string sp, string fv, string sv, string zc, string sr)
        {
            await Clients.Others.SendAsync("RecieveParameters", sp, fv, sv, zc, sr);
        }

        public async Task SendAction(string Action)
        {
            await Clients.Others.SendAsync("RecieveAction", Action);
        }

        public async Task SendData(string voltage, string current)
        {
            await Clients.Others.SendAsync("RecieveData", voltage, current);
        }
    }
}
