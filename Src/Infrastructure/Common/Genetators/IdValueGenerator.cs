using System.Threading;
using System.Threading.Tasks;
using IdGen;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace Infrastructure.Common.Genetators
{
    public class IdValueGenerator : ValueGenerator<string>
    {
        private static readonly IdGenerator Generator = new (0);
        
        public override string Next(EntityEntry entry)
        {
            return Generator.CreateId().ToString();
        }

        public override ValueTask<string> NextAsync(
            EntityEntry entry, 
            CancellationToken cancellationToken = new ())
        {
            return new (Next(entry));
        }

        public override bool GeneratesTemporaryValues => false;
    }
}