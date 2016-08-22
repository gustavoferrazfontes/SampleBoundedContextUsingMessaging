using System.Linq;
using SharedKernel.Events;
using SharedKernel.Interfaces;
using System.Collections.Generic;

namespace Shipping.Core.ApplicationLayer.UseCases
{
    public class UseCase
    {
        private readonly INotifiable<DomainNotification> _domainNotification;
        private readonly IUnitOfWork _uow;
        public UseCase(INotifiable<DomainNotification> domainNotification, IEnumerable<IUnitOfWork> uow)
        {
            _domainNotification = domainNotification;
            _uow = uow.First(_ => _.GetType().Name == "ShippingUnitOfWork");
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
