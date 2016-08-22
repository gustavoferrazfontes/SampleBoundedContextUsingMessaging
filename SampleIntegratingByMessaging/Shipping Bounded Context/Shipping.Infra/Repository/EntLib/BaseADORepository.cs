using Microsoft.Practices.EnterpriseLibrary.Data;

namespace Shipping.Infra.Repository.EntLib
{
    public class BaseADORepository
    {
        public Database Context { get { return new DatabaseProviderFactory().Create("ShippingContext"); } }
    }
}
