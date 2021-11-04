using System.Collections.Generic;
using System.Threading.Tasks;
using ApiProject.Domain;

namespace ApiProject.DataAccess.product
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllProductAsync();

        Task<Product> GetProductByIdAsync(int Id);
        Task<Product> GetProductBySlugAsync(string Slug);


        void AddProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(int Id);

    }
}