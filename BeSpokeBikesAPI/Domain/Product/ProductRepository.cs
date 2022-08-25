using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace BeSpokeBikesAPI
{ 
    public class ProductRepository : IProductRepository
    {
        private static string m_ConnectionString = @"Data Source=localhost;Initial Catalog=BeSpokeBikes;Integrated Security=True;Encrypt=false";

        public async Task<List<Product>> GetAllAsync()
        {     
            using (var c = new SqlConnection(m_ConnectionString))
            {
                var products = await c.QueryAsync<Product>(
                    @"SELECT * FROM BeSpokeBikes.dbo.Product"
                );

                return products.ToList();
            }
        }
    }
}
