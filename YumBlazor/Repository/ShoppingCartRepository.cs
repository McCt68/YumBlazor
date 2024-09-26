using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System.CodeDom.Compiler;
using YumBlazor.Components.Pages.Cart_Pages;
using YumBlazor.Data;
using YumBlazor.Repository.IRepository;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace YumBlazor.Repository
{
    public class ShoppingCartRepository : IShoppingCartRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public ShoppingCartRepository(ApplicationDbContext db)
        {
            _dbContext = db;
        }
        public async Task<bool> ClearCartAsync(string? userId)
        {
            var cartItems = await _dbContext.ShoppingCart.Where(u => u.UserId == userId).ToListAsync();
            _dbContext.ShoppingCart.RemoveRange(cartItems);

             return await _dbContext.SaveChangesAsync() > 0; // save and return if we deleted any items
        }

        public async Task<IEnumerable<ShoppingCart>> GetAllAsync(string? userId)
        {
            // Get rows from ShoppingCart table where -
            // ShoppingCart.UserId = userId provided as the argument when calling this method -
            // And also include ShoppingCart.Product -
            // And return them all as a List

            // .Where(u => u.UserId == userId): This filters the collection of shopping cart items -
            // based on the specified userId. It selects only the items that belong to the given user.

            // .Include(u => u.Product): This eagerly loads the related Product entity -
            // for each shopping cart item.This means that when the query is executed, -
            // the database will fetch not only the shopping cart items -
            // but also the corresponding product details for each item.
            return await 
                _dbContext.ShoppingCart.Where(u => u.UserId == userId).Include(u => u.Product)
                .ToListAsync();
        }

        public Task<bool> UpdateCartAsync(string userId, int prodcut, int updateBy)
        {
            throw new NotImplementedException();
        }
    }
}
