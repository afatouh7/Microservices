using Microsoft.Extensions.Logging;
using Ordering.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ordering.Infrastructure.Persistance
{
    public class OrderContextSeed
    {
        public static async Task SeedAsync(OrderContext orderContext ,ILogger<OrderContextSeed> logger )
        {
            if (!orderContext.Orders.Any())
            {
                orderContext.Orders.AddRange(GetPreconfiguredOrders());
                await orderContext.SaveChangesAsync();
                logger.LogInformation("Seed Database associted with context {DbContextName}", typeof(OrderContext).Name);
            }
        }


        private static IEnumerable<Order> GetPreconfiguredOrders()
        {
            return new List<Order>
            {
                new Order(){UserName="fatouh",FirstName="Ahmed",LastName="fatouh",EmailAddress="fatouh_a@yahoo.com",Country="Egypt",TotalPrice=350,State="cairo"}
            };
        }
    }
}
