using SharedKernel.Events.Interfaces;
using System;
using System.Collections.Generic;

namespace SharedKernel.Interfaces
{
    public interface INotifiable<T> : IDisposable where T : IDomainEvent
    {
        IEnumerable<T> Notify();
        bool HasNotifications();
    }
}
