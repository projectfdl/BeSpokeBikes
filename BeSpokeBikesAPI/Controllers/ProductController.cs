using Microsoft.AspNetCore.Mvc;

namespace BeSpokeBikesAPI.Controllers
{
    [ApiController]
    [Route("/api/product")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IProductRepository m_ProductRepository;

        public ProductController(ILogger<ProductController> logger, IProductRepository salespersonRepository)
        {
            _logger = logger;
            m_ProductRepository = salespersonRepository;
        }

        [HttpGet]
        public async Task<List<Product>> GetAsync()
        {
            return await m_ProductRepository.GetAllAsync();
        }
    }
}