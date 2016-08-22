using Orders.Core.ApplicationLayer.Handlers;
using Orders.Core.ApplicationLayer.Interfaces;
using Orders.Core.ApplicationLayer.UseCases;
using Orders.Core.Domain.Events;
using Orders.Core.Domain.Interfaces.Repository;
using Orders.Infra.config;
using Orders.Infra.Context;
using Orders.Infra.Publishers;
using Orders.Infra.Repository.EF;
using SharedKernel.Commands.Interfaces;
using SharedKernel.Events;
using SharedKernel.Interfaces;
using Shipping.Core.ApplicationLayer.Commands;
using Shipping.Core.ApplicationLayer.Handlers;
using Shipping.Core.ApplicationLayer.Interfaces;
using Shipping.Core.ApplicationLayer.Queries;
using Shipping.Core.Domain.Interfaces.Repository;
using Shipping.Infra.config;
using Shipping.Infra.Context;
using Shipping.Infra.Repository.EF;
using Shipping.Infra.Repository.EntLib;
using SimpleInjector;

namespace IoC
{
    public sealed class BootsTrapper
    {
        public static void Register(Container container)
        {
            container.RegisterPerWebRequest<IOrdersManagement, OrdersManagement>();
            container.RegisterPerWebRequest<IShippingQuery, ShippingQuery>();

            var domainHandler = Lifestyle.Singleton.CreateRegistration<DomainNotificationHandler>(container);
            var orderPlacedHandler = Lifestyle.Singleton.CreateRegistration<OrderPlacedHandler>(container);
            var orderPlacedPublisher = Lifestyle.Singleton.CreateRegistration<OrderPlacedPublisher>(container);
            var newShippingCommandSubscriber = Lifestyle.Singleton.CreateRegistration<NewOrderForShippingHandler>(container);

            container.RegisterSingleton<ShippingContext>();
            container.RegisterSingleton<OrderContext>();
            container.RegisterSingleton<IShippingRepository, ShippingRepository>();
            container.RegisterSingleton<IShippingADORepository, ShippingADORepository>();
            container.RegisterSingleton<IOrderRepository, OrderRepository>();



            container.AddRegistration(typeof(INotifiable<DomainNotification>), domainHandler);
            container.AddRegistration(typeof(IEventHandler<DomainNotification>), domainHandler);
            container.AddRegistration(typeof(IEventHandler<OrderPlaced>), orderPlacedHandler);
            container.AddRegistration(typeof(IMessagePublisher<OrderPlaced>), orderPlacedPublisher);
            container.AddRegistration(typeof(IMessageHandler<NewShippingCommand>), newShippingCommandSubscriber);
            container.RegisterCollection<IUnitOfWork>(new[] { typeof(ShippingUnitOfWork).Assembly, typeof(OrderUnitOfWork).Assembly });

        }
    }
}
