using System;

namespace SharedKernel.Events.Interfaces
{
    public interface IDomainEvent
    {
        DateTime DateOccurred { get; }
    }
}
