using YumBlazor.Data;

namespace YumBlazor.Repository.IRepository
{
    public interface ICategoryRepository
    {
        // EndPoints for Category
        public Task<Category> CreateAsync(Category obj);
        public Task<Category> UpdateAsync(Category obj);
        public Task<bool> DeleteAsync(int id); // return bool to tell if it was successfully deleted
        public Task<Category> GetAsync(int id); // Get single Category

        // IEnumerable in C# is an interface that defines a sequence of elements -
        // that can be iterated over.
        // It provides a common contract for various collection types, -
        // allowing you to use a unified way to access and process their elements.
        public Task<IEnumerable<Category>> GetAllAsync(); // Get all Category
    }
}
