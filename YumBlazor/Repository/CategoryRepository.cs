using Microsoft.EntityFrameworkCore;
using YumBlazor.Data;
using YumBlazor.Repository.IRepository;

namespace YumBlazor.Repository
{
    // Implements the ICategoryInterface
    public class CategoryRepository : ICategoryRepository
    {
        // We need an instance of  DbContext to perform all the CRUD operations
        private readonly ApplicationDbContext _dbContext;

        public CategoryRepository(ApplicationDbContext db)
        {
            _dbContext = db;
        }
        public async Task<Category> CreateAsync(Category obj)
        {
            await _dbContext.Category.AddAsync(obj);
            await _dbContext.SaveChangesAsync();
            return obj;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var obj = await _dbContext.Category.FirstOrDefaultAsync(u => u.Id == id);
            if (obj != null)
            {
                _dbContext.Category.Remove(obj);

                // SaveChanges() will return an int with how many records was updated -
                // If that value is greater than zero, it means the delete was successfull.
                return (await _dbContext.SaveChangesAsync()) > 0; // will return true
            }
            return false; // If the delete was not successfull
        }

        public async Task<Category> GetAsync(int id)
        {
            var obj = await _dbContext.Category.FirstOrDefaultAsync(u => u.Id == id);
            if(obj == null)
            {
                return new Category();
            }
            return obj;
        }

        // Maybe this is not async ?? video 92
        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _dbContext.Category.ToListAsync();
        }

        public async Task<Category> UpdateAsync(Category obj)
        {
            var objFromDb = await _dbContext.Category.FirstOrDefaultAsync(u=> u.Id == obj.Id);
            if(objFromDb is not null)
            {
                objFromDb.Name = obj.Name;
                _dbContext.Category.Update(objFromDb);
                await _dbContext.SaveChangesAsync();
                return objFromDb;
            }
            return obj;
        }
    }
}
