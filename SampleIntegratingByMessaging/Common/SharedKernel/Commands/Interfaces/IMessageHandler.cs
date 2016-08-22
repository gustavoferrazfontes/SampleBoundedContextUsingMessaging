using System;

namespace SharedKernel.Commands.Interfaces
{
    public interface IMessageHandler<T> : IDisposable where T : ICommand
    {
        void Handle(T args);
    }
}
