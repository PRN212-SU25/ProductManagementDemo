using BusinessObjects;

namespace Repositories
{
    public interface IProductRepository
    {
        void SaveProduct(Product p);
        void UpdateProduct(Product p);
        void DeleteProduct(Product p);

        List<Product> GetProducts();
        Product GetProductById(int id);
    }
}
