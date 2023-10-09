using Discount.Grpc.Protos;
using System.Threading.Tasks;

namespace Baskets.Api.GrpcServices
{
    public class DiscountGrpcService
    {
        private readonly DiscountProtoService.DiscountProtoServiceClient _discountProtoServiceClient;
        public DiscountGrpcService(DiscountProtoService.DiscountProtoServiceClient discountProtoServiceClient)
        {
            _discountProtoServiceClient = discountProtoServiceClient;
        }
        public async Task<CouponModel> GetDiscount(string productName)
        {
            var discontRequest = new GetDiscountRequest { ProductName = productName };
            return await _discountProtoServiceClient.GetDiscountAsync(discontRequest);
        }
    }
}
