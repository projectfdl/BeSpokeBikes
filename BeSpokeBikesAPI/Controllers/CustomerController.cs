using Microsoft.AspNetCore.Mvc;

namespace BeSpokeBikesAPI.Controllers
{
    [ApiController]
    [Route("/api/customer")]
    public class CustomerController : ControllerBase
    {
        private readonly ILogger<CustomerController> _logger;
        private readonly ICustomerRepository m_CustomerRepository;

        public CustomerController(ILogger<CustomerController> logger, ICustomerRepository customerRepository)
        {
            _logger = logger;
            m_CustomerRepository = customerRepository;
        }

        [HttpGet]
        public async Task<List<Customer>> GetAsync()
        {
            return await m_CustomerRepository.GetAllAsync();
        }
    }
}