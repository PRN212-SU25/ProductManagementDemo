using BusinessObjects;

namespace Repositories
{
    public interface IProductRepository
    {
        void SaveProduct(Product p);
        void UpdateProduct(Product p);
        void DeleteProduct(int id);

        List<Product> GetProducts();
        Product GetProductById(int id);
    }
}
