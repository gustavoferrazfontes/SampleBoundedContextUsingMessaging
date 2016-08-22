using System.Collections.Generic;
using SharedKernel.Events;
using SharedKernel.Interfaces;

namespace Orders.Core.ApplicationLayer.Handlers
{
    public class DomainNotificationHandler :IEventHandler<DomainNotification> ,INotifiable<DomainNotification>
    {
        List<DomainNotification> lst;

        public DomainNotificationHandler()
        {
            lst = new List<DomainNotification>();
        }
        public void Dispose()
        {
            lst = new List<DomainNotification>();
        }

        public void Handle(DomainNotification args)
        {
            lst.Add(args);
        }

        public bool HasNotifications()
        {
            return lst.Count > 0;
        }

        public IEnumerable<DomainNotification> Notify()
        {
            return lst;
        }
    }
}
