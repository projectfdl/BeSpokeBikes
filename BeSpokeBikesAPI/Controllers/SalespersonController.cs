using Microsoft.AspNetCore.Mvc;

namespace BeSpokeBikesAPI.Controllers
{
    [ApiController]
    [Route("/api/salesperson")]
    public class SalespersonController : ControllerBase
    {
        private readonly ILogger<SalespersonController> _logger;
        private readonly ISalespersonRepository m_SalespersonRepository;

        public SalespersonController(ILogger<SalespersonController> logger, ISalespersonRepository salespersonRepository)
        {
            _logger = logger;
            m_SalespersonRepository = salespersonRepository;
        }

        [HttpGet]
        public async Task<List<Salesperson>> GetAsync()
        {
            return await m_SalespersonRepository.GetAllAsync();
        }
    }
}