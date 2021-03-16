// HermesChat - Simple real-time chat application.
// Copyright (C) 2021  Jerrett D. Davis
// 
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see <https://www.gnu.org/licenses/>.

using System.Threading.Tasks;
using Application.Servers.Models.Hubs.Responses;
using Microsoft.AspNetCore.SignalR;

namespace Application.Servers.Hubs
{
    public class ServerHub : Hub<IServerHub>
    {
        // public async Task JoinServer(JoinServerRequest request)
        // {
        //     //Clients.Caller.JoinedServer()
        // }
    }

    public interface IServerHub
    {
        Task JoinedServer(JoinedServerResponse response);
    }
}