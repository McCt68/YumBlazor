using YumBlazor.Data;

namespace YumBlazor.Repository.IRepository
{
    public interface IShoppingCartRepository
    {
        // Returns a bool
        public Task<bool> UpdateCartAsync(string userId, int product, int updateBy);

        // Retrive ShoppingCart for that user as a IEnumerable - kinda List
        public Task<IEnumerable<ShoppingCart>> GetAllAsync(string? userId); 
        public Task<bool> ClearCartAsync(string? userId);
    }
}
