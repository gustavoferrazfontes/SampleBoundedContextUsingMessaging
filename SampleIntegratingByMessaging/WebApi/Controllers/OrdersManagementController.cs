using Orders.Core.ApplicationLayer.Commands;
using Orders.Core.ApplicationLayer.Interfaces;
using SharedKernel.Events;
using SharedKernel.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using WebApi.Models;

namespace WebApi.Controllers
{
    [RoutePrefix("api/orders")]
    public class OrdersManagementController : ApiController
    {
        private readonly IOrdersManagement _ordersManagement;
        private readonly INotifiable<DomainNotification> _notifications;
        public OrdersManagementController(IOrdersManagement ordesManagement, INotifiable<DomainNotification> notifications)
        {
            _ordersManagement = ordesManagement;
            _notifications = notifications;
        }

        [Route("order")]
        [HttpPost]
        public async Task<IHttpActionResult> PostAsync(OrderViewModel body)
        {
            var itemsCommand = new List<CreateOrderItemCommand>();
            body
                .Items
                .ForEach(item => itemsCommand.Add(new CreateOrderItemCommand(item.Quantity, item.ProductId)));
            var command = new PlaceAnOrderCommand
                (
                    body.userId,
                    itemsCommand
                );

            _ordersManagement.PlaceAnOrder(command);

            if (_notifications.HasNotifications())
            {
                _notifications.Notify().ToList().ForEach(error => ModelState.AddModelError(error.Key, error.Value));
                return await Task.FromResult(BadRequest(ModelState));
            }
            return await Task.FromResult(Ok());
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            _notifications.Dispose();
        }
    }
}
