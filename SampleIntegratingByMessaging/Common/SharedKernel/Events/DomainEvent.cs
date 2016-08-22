using SharedKernel.Events.Interfaces;
using SharedKernel.Interfaces;
using System;

namespace SharedKernel.Events
{
    public static class DomainEvent
    {
        public static IContainer Container { get; set; }

        public static void Raise<T>(T args) where T : IDomainEvent
        {
            try
            {
                if (Container != null)
                {
                    var obj = Container.GetService(typeof(IEventHandler<T>));
                    ((IEventHandler<T>)obj).Handle(args);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error in container events", ex);
            }
        }
    }
}
