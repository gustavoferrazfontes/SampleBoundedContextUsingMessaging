using SharedKernel.Events.Interfaces;
using System;

namespace SharedKernel.Interfaces
{
    public interface IEventHandler<T> : IDisposable where T : IDomainEvent
    {
        void Handle(T args);

    }
}
