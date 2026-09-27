using Product_api.Model;

namespace Product_api.Services
{
    public interface IProductServices
    {
        List<Product> GetAll(Product product);
    }
}