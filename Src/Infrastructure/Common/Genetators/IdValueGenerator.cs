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
using IdGen;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace Infrastructure.Common.Genetators
{
    public class IdValueGenerator : ValueGenerator<string>
    {
        private static readonly IdGenerator Generator = new(0);

        public override bool GeneratesTemporaryValues => false;

        public override string Next(EntityEntry entry)
        {
            return Generator.CreateId().ToString();
        }

        public override ValueTask<string> NextAsync(
            EntityEntry entry,
            CancellationToken cancellationToken = new())
        {
            return new(Next(entry));
        }
    }
}