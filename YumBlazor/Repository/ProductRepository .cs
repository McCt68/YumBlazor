using Microsoft.EntityFrameworkCore;
using YumBlazor.Data;
using YumBlazor.Repository.IRepository;

namespace YumBlazor.Repository
{
    // Implements the IProductInterface
    public class ProductRepository : IProductRepository
    {
        // We need an instance of  DbContext to perform all the CRUD operations
        private readonly ApplicationDbContext _dbContext;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProductRepository(ApplicationDbContext db, IWebHostEnvironment webHostEnvironment)
        {
            _dbContext = db;
            _webHostEnvironment = webHostEnvironment;
        }
        public async Task<Product> CreateAsync(Product obj)
        {
            await _dbContext.Product.AddAsync(obj);
            await _dbContext.SaveChangesAsync();
            return obj;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var obj = await _dbContext.Product.FirstOrDefaultAsync(u => u.Id == id);

            // Remove the forward slash from the string that is saved in the DB
            var imagePath = Path.Combine(_webHostEnvironment.WebRootPath, obj.ImageUrl.TrimStart('/'));
            if (File.Exists(imagePath))
            {
                File.Delete(imagePath);
            }
            if (obj != null)
            {
                _dbContext.Product.Remove(obj);

                // SaveChanges() will return an int with how many records was updated -
                // If that value is greater than zero, it means the delete was successfull.
                return (await _dbContext.SaveChangesAsync()) > 0; // will return true
            }
            return false; // If the delete was not successfull
        }

        public async Task<Product> GetAsync(int id)
        {
            var obj = await _dbContext.Product.FirstOrDefaultAsync(u => u.Id == id);
            if(obj == null)
            {
                return new Product();
            }
            return obj;
        }

        // Maybe this is not async ?? video 92
        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _dbContext.Product.Include(u => u.Category).ToListAsync();
        }

        public async Task<Product> UpdateAsync(Product obj)
        {
            var objFromDb = await _dbContext.Product.FirstOrDefaultAsync(u=> u.Id == obj.Id);
            if(objFromDb is not null)
            {
                objFromDb.Name = obj.Name;
                objFromDb.Description = obj.Description;                
                objFromDb.ImageUrl = obj.ImageUrl;
                objFromDb.CategoryId = obj.CategoryId;
                objFromDb.Price = obj.Price;
                _dbContext.Product.Update(objFromDb);
                await _dbContext.SaveChangesAsync();
                return objFromDb;
            }
            return obj;
        }
    }
}
