using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using ApiProject.Domain;
using Dapper;
using Microsoft.Extensions.Configuration;
namespace ApiProject.DataAccess


{
    public class DeveloperRepository : IDeveloperRepository
    {
        protected readonly IConfiguration _config;

        public DeveloperRepository(IConfiguration config)
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

        public void AddDeveloper(Developer developer)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    string query = @"INSERT INTO Developer(Name,Address,Pin,Phone) VALUES (@Name,@Address,@Pin,@Phone)";
                    dbConnection.Execute(query, developer);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        public void DeleteDeveloper(int Id)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    string query = @"DELETE FROM Developer WHERE Id=@id ";
                    dbConnection.Execute(query, new { Id = Id });

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<IEnumerable<Developer>> GetAllDeveloperAsync()
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    string query = @"SELECT * FROM Developer ORDER BY Id DESC";
                    return await dbConnection.QueryAsync<Developer>(query);

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<Developer> GetDeveloperByEmailAsync(string Email)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    string query = @"SELECT * FROM Developer WHERE Email=@Email";
                    return await dbConnection.QueryFirstOrDefaultAsync<Developer>(query, new { Email = Email });

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Developer> GetDeveloperByIdAsync(int Id)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    string query = @"SELECT * FROM Developer WHERE Id=@Id ORDER BY Id DESC";
                    return await dbConnection.QueryFirstOrDefaultAsync<Developer>(query, new { Id = Id });

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateDeveloper(Developer developer)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    string query = @"UPDATE Developer SET Name=@Name, Email=@Email, Address=@Address, Pin=@Pin, Phone=@Phone WHERE Id=@Id";
                    dbConnection.Execute(query, developer);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}