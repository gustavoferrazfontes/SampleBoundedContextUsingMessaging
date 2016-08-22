using SharedKernel.Events;
using SharedKernel.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Orders.Core.ApplicationLayer.UseCases
{
    public class UseCase
    {
        private readonly INotifiable<DomainNotification> _domainNotification;
        private readonly IUnitOfWork _uow;
        public UseCase(INotifiable<DomainNotification> domainNotification, IEnumerable<IUnitOfWork> uow)
        {
            _domainNotification = domainNotification;
            _uow = uow.First(_ => _.GetType().Name == "OrderUnitOfWork");
        }

        public bool Commit()
        {
            if (_domainNotification.HasNotifications())
            {
                _uow.Rollback();
                return false;
            }
            else
            {
                _uow.Commit();
                return true;
            }
        }

    }
}
