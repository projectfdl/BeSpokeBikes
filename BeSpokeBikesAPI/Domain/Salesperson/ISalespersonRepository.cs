namespace BeSpokeBikesAPI
{
    public interface ISalespersonRepository
    {
        Task<List<Salesperson>> GetAllAsync(); 
    }
}
