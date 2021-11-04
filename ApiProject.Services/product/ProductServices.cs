using System.Collections.Generic;
using System.Threading.Tasks;
using ApiProject.DataAccess.product;
using ApiProject.Domain;

namespace ApiProject.Services.product
{
    public class ProductServices : IProductServices
    {
        public readonly IProductRepository _productRepository;

        public ProductServices(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public void AddProduct(Product product)
        {
            _productRepository.AddProduct(product);
        }

        public void DeleteProduct(int Id)
        {
            _productRepository.DeleteProduct(Id);
        }

        public async Task<IEnumerable<Product>> GetAllProductAsync()
        {
            return await _productRepository.GetAllProductAsync();
        }

        public async Task<Product> GetProductByIdAsync(int Id)
        {

            return await _productRepository.GetProductByIdAsync(Id);
        }

        public async Task<Product> GetProductBySlugAsync(string Slug)
        {
            return await _productRepository.GetProductBySlugAsync(Slug);
        }

        public void UpdateProduct(Product product)
        {
            _productRepository.UpdateProduct(product);
        }
    }
}