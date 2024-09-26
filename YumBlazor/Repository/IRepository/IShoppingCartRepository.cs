using YumBlazor.Data;

namespace YumBlazor.Repository.IRepository
{
    public interface IShoppingCartRepository
    {
        public Task<bool> UpdateCartAsync(string userId, int prodcut, int updateBy);

        // Retrive ShoppingCart for that user as a IEnumerable - kinda List
        public Task<IEnumerable<ShoppingCart>> GetAllAsync(string? userId); 
        public Task<bool> ClearCartAsync(string? userId);
    }
}
