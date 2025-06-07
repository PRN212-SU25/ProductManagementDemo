using BusinessObjects;
using DataAccessLayer;

namespace Repositories
{
    public class ProductRepository : IProductRepository
    {
        public void DeleteProduct(int id) => ProductDAO.DeleteProduct(id);

        public Product GetProductById(int id) => ProductDAO.GetProductById(id);

        public List<Product> GetProducts() => ProductDAO.GetAllProducts();

        public void SaveProduct(Product p) => ProductDAO.AddProduct(p);

        public void UpdateProduct(Product p) => ProductDAO.UpdateProduct(p);
    }
}
