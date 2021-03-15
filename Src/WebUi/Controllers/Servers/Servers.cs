using System.Threading;
using System.Threading.Tasks;
using Application.Servers.Commands.CreateServer;
using Microsoft.AspNetCore.Mvc;
using WebUi.Models.Requests.Servers;
using WebUi.Models.Responses.Servers;

namespace WebUi.Controllers.Servers
{
    public class Servers : ApiControllerBase
    {
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
                actionName: nameof(GetServer), 
                routeValues: new {serverId = server.Id}, 
                value: response);
        }  
    }
}