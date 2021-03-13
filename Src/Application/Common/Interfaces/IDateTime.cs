using System;

namespace Application.Common.Interfaces
{
    public interface IDateTime
    {
        public DateTime Now => DateTime.Now;
        public DateTime UtcNow => DateTime.UtcNow;
    }
}