using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using ApiProject.Domain;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace ApiProject.DataAccess.userRole
{
    public class UserRoleRepository : IUserRoleRepository
    {
        protected readonly IConfiguration _config;

        public UserRoleRepository(IConfiguration config)
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

        public void AddUserRole(UserRole userRole)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    string query = @"INSERT INTO UserRole(Role) VALUES (@Role)";
                    dbConnection.Execute(query, userRole);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteUserRole(int Id)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    string query = @"DELETE FROM UserRole WHERE Id=@id";
                    dbConnection.Execute(query, new { Id = Id });

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<UserRole>> GetAllUserRoleAsync()
        {

            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    string query = @"SELECT * FROM UserRole ORDER BY Id DESC";
                    return await dbConnection.QueryAsync<UserRole>(query);

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<UserRole> GetUserRoleByIdAsync(int Id)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    string query = @"SELECT * FROM UserRole WHERE Id=@Id";
                    return await dbConnection.QueryFirstOrDefaultAsync<UserRole>(query, new { Id = Id });

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void UpdateUserRole(UserRole userRole)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    string query = @"UPDATE UserRole SET Role=@Role, 
                    IsActive=@IsActive
                     WHERE Id=@Id";
                    dbConnection.Execute(query, userRole);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}