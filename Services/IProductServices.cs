using Product_api.Model;

namespace Product_api.Services
{
    public interface IProductServices
    {
       
        List<Product> ListByName(string product);
        Product ListById(int id);
        Product Add(Product product);
        Product DeleteProduct(int id);
        Product Update(Product id);
        List <Product> GetAll();
    }
}