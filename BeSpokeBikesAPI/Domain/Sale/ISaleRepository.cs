namespace BeSpokeBikesAPI
{
    public interface ISaleRepository
    {
        Task<List<Sale>> GetAllAsync(); 
    }
}
