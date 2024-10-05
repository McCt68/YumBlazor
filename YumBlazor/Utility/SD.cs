using YumBlazor.Data;

namespace YumBlazor.Utility
{
	public static class SD // Static Details
	{
		public static string Role_Admin = "Admin";
		public static string Role_Customer = "Customer";

		public static string StatusPending = "Pending";
		public static string StatusReadyForPickup = "ReadyForPickup";
		public static string StatusCompleted = "Completed";
		public static string StatusCanceled = "Canceled";

		// helper method - Used in Cart.razor - To convert
		public static List<OrderDetail> ConvertShoppingCartListToOrderDetail(List<ShoppingCart> shoppingCarts)
		{
			List<OrderDetail> orderDetails = new List<OrderDetail>();

			foreach (ShoppingCart cart in shoppingCarts)
			{
				OrderDetail orderDetail = new OrderDetail
				{
					ProductId = cart.ProductId,
					Count = cart.Count,
					Price = Convert.ToDouble(cart.Product.Price), // Original do not delete
					// Price = cart.Product.Price, // Can delete
					ProductName = cart.Product.Name
				};
				orderDetails.Add(orderDetail);
			}
			return orderDetails;
		}
	}
}
