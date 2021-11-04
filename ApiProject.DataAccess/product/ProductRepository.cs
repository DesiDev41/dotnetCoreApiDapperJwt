using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using ApiProject.Domain;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace ApiProject.DataAccess.product
{
    public class ProductRepository : IProductRepository
    {
        protected readonly IConfiguration _config;

        public ProductRepository(IConfiguration config)
        {
            _config = config;
        }

        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(_config.GetConnectionString("DbConnection"));
            }
        }

        public void AddProduct(Product product)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    string query = @"INSERT INTO Product(ProductName,ProductSlug,ProductDescription,ProductImage,ProductPrice,IsActive) VALUES (@ProductName,@ProductSlug,@ProductDescription,@ProductImage,@ProductPrice,@IsActive)";
                    dbConnection.Execute(query, product);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void DeleteProduct(int Id)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    string query = @"DELETE FROM Product WHERE Id=@id";
                    dbConnection.Execute(query, new { Id = Id });

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<Product>> GetAllProductAsync()
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    string query = @"SELECT * FROM Product ORDER BY Id DESC";
                    return await dbConnection.QueryAsync<Product>(query);

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<Product> GetProductByIdAsync(int Id)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    string query = @"SELECT * FROM Product WHERE Id=@Id";
                    return await dbConnection.QueryFirstOrDefaultAsync<Product>(query, new { Id = Id });

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Product> GetProductBySlugAsync(string ProductSlug)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    string query = @"SELECT * FROM Product WHERE ProductSlug=@ProductSlug";
                    return await dbConnection.QueryFirstOrDefaultAsync<Product>(query, new { ProductSlug = ProductSlug });

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateProduct(Product product)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    string query = @"UPDATE Product SET ProductName=@ProductName, ProductSlug=@ProductSlug, ProductDescription=@ProductDescription, ProductImage=@ProductImage, ProductPrice=@ProductPrice,
                    IsActive=@IsActive
                     WHERE Id=@Id";
                    dbConnection.Execute(query, product);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}