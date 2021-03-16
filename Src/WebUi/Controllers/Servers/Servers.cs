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

using System.Threading;
using System.Threading.Tasks;
using Application.Servers.Commands.CreateServer;
using Application.Servers.Queries.GetCurrentUserServers;
using Microsoft.AspNetCore.Mvc;
using WebUi.Models.Requests.Servers;
using WebUi.Models.Responses.Servers;

namespace WebUi.Controllers.Servers
{
    public class Servers : ApiControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetServers(
            CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(
                new GetCurrentUserServersQuery(), cancellationToken); 
            return Ok(new GetUserServersResponse(response));
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetServer(
            string serverId,
            CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> CreateServer(
            CreateServerRequest request,
            CancellationToken cancellationToken)
        {
            var server = await Mediator.Send(
                new CreateServerCommand(request.ServerName),
                cancellationToken);
            var response = new CreateServerResponse(server);

            return CreatedAtAction(
                nameof(GetServer),
                new {serverId = server.Id},
                response);
        }
    }
}