using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace BeSpokeBikesAPI
{ 
    public class DiscountRepository : IDiscountRepository
    {
        private static string m_ConnectionString = @"Data Source=localhost;Initial Catalog=BeSpokeBikes;Integrated Security=True;Encrypt=false";

        public async Task<List<Discount>> GetAllAsync()
        {     
            using (var c = new SqlConnection(m_ConnectionString))
            {
                var discounts = await c.QueryAsync<Discount>(
                    @"SELECT * FROM BeSpokeBikes.dbo.Discount"
                );

                return discounts.ToList();
            }
        }
    }
}
