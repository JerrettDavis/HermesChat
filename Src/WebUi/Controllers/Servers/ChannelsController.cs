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
using Application.Servers.Channels.Queries.GetChannels;
using Microsoft.AspNetCore.Mvc;
using WebUi.Models.Responses.Servers;

namespace WebUi.Controllers.Servers
{
    [Route("Api/Servers/{serverId}/[controller]")]
    public class ChannelsController : ApiControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetChannels(
            string serverId,
            CancellationToken cancellationToken)
        {
            var channels = await Mediator.Send(
                new GetChannelsQuery(serverId), cancellationToken);

            return Ok(new GetChannelsResponse(channels));
        } 
    }
}