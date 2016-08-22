using SharedKernel.Events.Interfaces;

namespace SharedKernel.Interfaces
{
    public interface IMessagePublisher<T> where T : IDomainEvent
    {
        void Publish(T domainEvent);
    }
}
