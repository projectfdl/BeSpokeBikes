namespace BeSpokeBikesAPI
{
    public interface ICustomerRepository
    {
        Task<List<Customer>> GetAllAsync(); 
    }
}
