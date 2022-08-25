using Dapper;
using Microsoft.Data.SqlClient;

namespace BeSpokeBikesAPI
{ 
    public class SaleRepository : ISaleRepository
    {
        private static string m_ConnectionString = @"Data Source=localhost;Initial Catalog=BeSpokeBikes;Integrated Security=True;Encrypt=false";

        public async Task<List<Sale>> GetAllAsync()
        {     
            using (var c = new SqlConnection(m_ConnectionString))
            {
                var sales = await c.QueryAsync<Sale, Customer, Salesperson, Product, Sale>(
                    @"SELECT s.*, c.*, sp.*, p.* 
                        FROM BeSpokeBikes.dbo.Sale s
                        JOIN BeSpokeBikes.dbo.Customer c ON c.Id = s.CustomerId
                        JOIN BeSpokeBikes.dbo.Salesperson sp ON sp.Id = s.SalespersonId
                        JOIN BeSpokeBikes.dbo.Product p ON p.Id = s.ProductId",
                    (sale, customer, salesperson, product) =>
                    {
                        sale.Customer = customer;
                        sale.Salesperson = salesperson;
                        sale.Product = product;
                        return sale;
                    },
                    splitOn: "Id, Id, Id"
                );

                return sales.ToList();
            }
        }
    }
}
