namespace BeSpokeBikesAPI
{
    public interface IDiscountRepository
    {
        Task<List<Discount>> GetAllAsync(); 
    }
}
