using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Application.Common.Interfaces.Data;
using Domain.Models;
using MediatR;

namespace Application.Servers.Commands.CreateServer
{
    public class CreateServerCommand : IRequest<string>
    {
        public string ServerName { get; set; } = null!;
    }

    public class CreateServerCommandHandler : 
        IRequestHandler<CreateServerCommand, string>
    {
        private readonly IApplicationDbContext _context;
        private readonly ICurrentUserService _userService;

        public CreateServerCommandHandler(
            IApplicationDbContext context, 
            ICurrentUserService userService)
        {
            _context = context;
            _userService = userService;
        }

        public async Task<string> Handle(
            CreateServerCommand request, 
            CancellationToken cancellationToken)
        {
            var server = new Server(
                request.ServerName, 
                _userService.GetAttachedUserAsync()!);

            await _context.Servers.AddAsync(server, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return server.Id;
        }
    }
}