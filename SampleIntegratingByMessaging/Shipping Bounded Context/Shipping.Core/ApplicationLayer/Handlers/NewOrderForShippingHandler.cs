using SharedKernel.Commands.Interfaces;
using SharedKernel.Events;
using SharedKernel.Interfaces;
using Shipping.Core.ApplicationLayer.Commands;
using Shipping.Core.ApplicationLayer.UseCases;
using Shipping.Core.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;

namespace Shipping.Core.ApplicationLayer.Handlers
{
    public class NewOrderForShippingHandler : UseCase, IMessageHandler<NewShippingCommand>
    {
        private readonly IShippingRepository _shippingRepository;

        public NewOrderForShippingHandler
            (IShippingRepository shippingRepository,
            INotifiable<DomainNotification> notification,
            IEnumerable<IUnitOfWork> uow)
            : base(notification, uow)
        {
            _shippingRepository = shippingRepository;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Handle(NewShippingCommand args)
        {
            if (args.IsValid())
            {
                var newShipping =
                    new Domain.ShippingAggregate.Shipping(args.OrderId, args.UserId, args.ItemsQuantity);
                _shippingRepository.Create(newShipping);
                Commit();
            }
        }
    }
}
