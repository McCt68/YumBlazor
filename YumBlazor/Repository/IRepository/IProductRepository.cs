using YumBlazor.Data;

namespace YumBlazor.Repository.IRepository
{
    public interface IProductRepository
    {
        // EndPoints for Category
        public Task<Product> CreateAsync(Product obj);
        public Task<Product> UpdateAsync(Product obj);
        public Task<bool> DeleteAsync(int id); // return bool to tell if it was successfully deleted
        public Task<Product> GetAsync(int id); // Get single Product

        // IEnumerable in C# is an interface that defines a sequence of elements -
        // that can be iterated over.
        // It provides a common contract for various collection types, -
        // allowing you to use a unified way to access and process their elements.
        public Task<IEnumerable<Product>> GetAllAsync(); // Get all Product
    }
}
