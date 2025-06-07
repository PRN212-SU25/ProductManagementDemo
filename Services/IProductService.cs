using BusinessObjects;

namespace Services
{
    public interface IProductService
    {
        void SaveProduct(Product p);
        void DeleteProduct(int id);
        void UpdateProduct(Product p);        
        List<Product> GetProducts();
        Product GetProductById(int id);
    }
}
