using Microsoft.EntityFrameworkCore;
using YumBlazor.Data;
using YumBlazor.Repository.IRepository;

// maybe namespace here is wrong
namespace YumBlazor.Repository
{
	public class OrderRepository : IOrderRepository
	{
		private readonly ApplicationDbContext _dbContext;

		public OrderRepository(ApplicationDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		// I can call this method somewhere and give and Orderheader as argument -
		// to insert a new row into the OrderHeaderTable ?
		public async Task<OrderHeader> CreateOrderAsync(OrderHeader orderHeader)
		{
			orderHeader.OrderDate = DateTime.Now;
			await _dbContext.OrderHeader.AddAsync(orderHeader);
			await _dbContext.SaveChangesAsync();
			return orderHeader;
		}

		// Get all Orders or all from a specific userId if the argument is provided when calling
		public async Task<IEnumerable<OrderHeader>> GetAllOrdersOrdersAsync(string? userId = null)
		{
			if (!string.IsNullOrEmpty(userId))
			{
				return await _dbContext.OrderHeader.Where(u => u.UserId == userId).ToListAsync();
			}

            return await _dbContext.OrderHeader.ToListAsync();            
		}

		// Return a specific Order - Not sure if the lambda argument is right
		public async Task<OrderHeader> GetOrderAsync(int id)
		{
			return await _dbContext.OrderHeader
				.Include(u => u.OrderDetails).FirstOrDefaultAsync(u => u.OrderHeaderId == id);
		}

		public async Task<OrderHeader> UpdateOrderStatusAsync(int orderId, string status)
		{
			var orderHeader = _dbContext.OrderHeader.FirstOrDefault(d => d.OrderHeaderId == orderId);
			if (orderHeader != null)
			{
				orderHeader.OrderStatus = status;
				await _dbContext.SaveChangesAsync();
			}
			return orderHeader;
		}
	}
}
