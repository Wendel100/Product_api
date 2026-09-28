using Product_api.Db;
using Product_api.Model;

namespace Product_api.Services
{
    public class ProductServices : IProductServices
    {
        readonly ProductDbContext _product;
        public ProductServices(ProductDbContext product){
            _product = product;
        }

        public Product ListById(int id) => _product.Produtos.Find(id);
        public List<Product> ListByName(string name)
{
    return _product.Produtos
        .ToList() // força a execução no cliente (memória)
        .Where(p => p.Name.Contains(name, StringComparison.OrdinalIgnoreCase))
        .ToList();
}

        public Product Add(Product product)
        {

            _product.Produtos.Add(product);
            _product.SaveChanges();
            return product;
        }

        public Product DeleteProduct(int id)
        { var Del =  _product.Produtos.Find(id);
           _product.Produtos.Remove(Del);
           _product.SaveChanges();
           return Del;
        }

        public Product Update(Product id)
        { var Del = ListById(id.Id);
        if (Del == null) throw new System.Exception("Erro ao atualizar os dados");;
        Del.Name = Del.Name;
        Del.Price = Del.Price;
        Del.Description =Del.Description;
        _product.Produtos.Update(Del);
        _product.SaveChanges();
        return Del;
        }

        public List<Product> GetAll()
        {
            return _product.Produtos.ToList();
        }
    }
}