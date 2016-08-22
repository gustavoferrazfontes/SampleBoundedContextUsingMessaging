using Shipping.Core.Domain.Interfaces.Repository;
using System.Collections.Generic;
using Shipping.Core.ApplicationLayer.Queries;
using System.Data;
using System;

namespace Shipping.Infra.Repository.EntLib
{
    public class ShippingADORepository : BaseADORepository, IShippingADORepository
    {
        public IEnumerable<NewShipping> GetAll()
        {

            var query = "SELECT Id,OrderId,CreationDate FROM SHIPPING";
            var lstAllNewShippings = new List<NewShipping>();

            using (var reader = Context.ExecuteReader(CommandType.Text, query))
            {
                while (reader.Read())
                {


                    var shipping = new NewShipping
                    {
                        Id = reader["Id"].ToString(),
                        OrderId = reader["OrderId"].ToString(),
                        CreationDate = Convert.ToDateTime(reader["CreationDate"])
                    };

                    lstAllNewShippings.Add(shipping);
                }
            }

            return lstAllNewShippings;
        }
    }
}
