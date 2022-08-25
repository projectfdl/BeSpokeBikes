using Microsoft.AspNetCore.Mvc;

namespace BeSpokeBikesAPI.Controllers
{
    [ApiController]
    [Route("/api/sale")]
    public class SaleController : ControllerBase
    {
        private readonly ILogger<SaleController> _logger;

        public SaleController(ILogger<SaleController> logger, ISaleRepository salespersonRepository)
        {
            _logger = logger;
            m_SaleRepository = salespersonRepository;
        }

        [HttpGet]
        public async Task<List<Sale>> GetAsync()
        {
            return await m_SaleRepository.GetAllAsync();
        }

        private readonly ISaleRepository m_SaleRepository;
    }
}