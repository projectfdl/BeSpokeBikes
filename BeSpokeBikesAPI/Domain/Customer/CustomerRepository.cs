using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace BeSpokeBikesAPI
{ 
    public class CustomerRepository : ICustomerRepository
    {
        private static string m_ConnectionString = @"Data Source=localhost;Initial Catalog=BeSpokeBikes;Integrated Security=True;Encrypt=false";

        public async Task<List<Customer>> GetAllAsync()
        {     
            using (var c = new SqlConnection(m_ConnectionString))
            {
                var customers = await c.QueryAsync<Customer>(
                    @"SELECT * FROM BeSpokeBikes.dbo.Customer"
                );

                return customers.ToList();
            }
        }
    }
}
