namespace BeSpokeBikesAPI
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllAsync(); 
    }
}
