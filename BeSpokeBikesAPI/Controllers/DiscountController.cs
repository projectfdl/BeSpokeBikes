using Microsoft.AspNetCore.Mvc;

namespace BeSpokeBikesAPI.Controllers
{
    [ApiController]
    [Route("/api/discount")]
    public class DiscountController : ControllerBase
    {
        private readonly ILogger<DiscountController> _logger;

        public DiscountController(ILogger<DiscountController> logger, IDiscountRepository salespersonRepository)
        {
            _logger = logger;
            m_DiscountRepository = salespersonRepository;
        }

        [HttpGet]
        public async Task<List<Discount>> GetAsync()
        {
            return await m_DiscountRepository.GetAllAsync();
        }

        private readonly IDiscountRepository m_DiscountRepository;
    }
}