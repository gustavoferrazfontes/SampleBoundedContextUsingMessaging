using Shipping.Core.ApplicationLayer.Interfaces;
using System.Threading.Tasks;
using System.Web.Http;

namespace WebApi.Controllers
{
    [RoutePrefix("api/shipping")]
    public class ShippingManagementController : ApiController
    {

        private readonly IShippingQuery _shippingQuery;

        public ShippingManagementController(IShippingQuery shippingQuery)
        {
            _shippingQuery = shippingQuery;
        }

        [Route("newShippings")]
        [HttpGet]
        public async Task<IHttpActionResult> GetAsync()
        {
            return await Task.FromResult(Ok(_shippingQuery.GetAll()));
        }
    }
}
