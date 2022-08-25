using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace BeSpokeBikesAPI
{ 
    public class SalespersonRepository : ISalespersonRepository
    {
        private static string m_ConnectionString = @"Data Source=localhost;Initial Catalog=BeSpokeBikes;Integrated Security=True;Encrypt=false";

        public async Task<List<Salesperson>> GetAllAsync()
        {     
            using (var c = new SqlConnection(m_ConnectionString))
            {
                var salespersons = await c.QueryAsync<Salesperson, Salesperson, Salesperson>(
                    @"SELECT s.*, m.* 
                        FROM BeSpokeBikes.dbo.Salesperson s
                        LEFT JOIN BeSpokeBikes.dbo.Salesperson m ON s.ManagerId = m.Id",
                    (salesperson, manager) =>
                    {
                        salesperson.Manager = manager;
                        return salesperson;
                    },
                    splitOn: "Id"
                );

                return salespersons.ToList();
            }
        }
    }
}
