using Microsoft.AspNetCore.Mvc;
using Product_api.Model;
using Product_api.Services;

namespace Product_api.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        
        private readonly IProductServices _product;

        [HttpGet("item/{id}")]
        public IActionResult GetId(int id)
        {
            var item = _product.ListById(id);
            if (item == null)
                return NotFound();

            return Ok(item);
        }

        [HttpGet("name/{name}")]
        public IActionResult GetName(string name)
        {
            var products = _product.ListByName(name);
            return Ok(products);
        }

        [HttpGet("all")]
        public IActionResult GetAll()
        {
            List<Product> products = _product.GetAll();
            return Ok(products);
        }

        [HttpPost("add")]
        public IActionResult ToAdd([FromBody] Product product)
        {
            _product.Add(product);
            return Ok($"Adicionado com sucesso: {product.Name}");
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            _product.DeleteProduct(id);
            return Ok($"Produto apagado: {id}");
        }

        [HttpPut("update")]
        public IActionResult ToUpdate([FromBody] Product product)
        {
            _product.Update(product);
            return Ok($"Produto atualizado: {product.Id}");
        }
    }
}