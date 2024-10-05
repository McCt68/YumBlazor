using YumBlazor.Data;

namespace YumBlazor.Repository.IRepository
{
	public interface IOrderRepository
	{
		public Task<OrderHeader> CreateOrderAsync(OrderHeader orderHeader);

		public Task<OrderHeader> GetOrderAsync(int id);

		// Get all Orders for a specific user
		public Task<IEnumerable<OrderHeader>> GetAllOrdersOrdersAsync(string? userId = null);

		public Task<OrderHeader> UpdateOrderStatusAsync(int orderId, string status);

    }
}
