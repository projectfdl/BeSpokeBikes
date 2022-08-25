using Microsoft.AspNetCore.Mvc;

namespace BeSpokeBikesAPI.Controllers
{
    [ApiController]
    [Route("/api/customer")]
    public class CustomerController : ControllerBase
    {
        private readonly ILogger<CustomerController> _logger;

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

        private readonly ICustomerRepository m_CustomerRepository;
    }
}