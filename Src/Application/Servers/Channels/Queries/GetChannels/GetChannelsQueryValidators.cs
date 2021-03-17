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

using System.Net;
using Application.Servers.Services;
using FluentValidation;
using JetBrains.Annotations;

namespace Application.Servers.Channels.Queries.GetChannels
{
    [UsedImplicitly]
    public class GetChannelsQueryValidators :
        AbstractValidator<GetChannelsQuery>
    {
        public GetChannelsQueryValidators(IServerValidators validators)
        {
            RuleFor(c => c.ServerId)
                .MustAsync(validators.ServerExists)
                .WithMessage("Server does not exist!")
                .WithErrorCode(HttpStatusCode.NotFound.ToString());
        }
    }
}