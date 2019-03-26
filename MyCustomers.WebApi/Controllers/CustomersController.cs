using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyCustomers.Application.Dto.Requests;
using MyCustomers.Application.Services;
using MyCustomers.Infrastructure.Core;

namespace MyCustomers.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly ILogger<CustomersController> _logger;

        public CustomersController(ICustomerService customerService, ILogger<CustomersController> logger)
        {
            _customerService = customerService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get(GetCustomersRequest request)
        {
            var requestStatus = request.Validate();
            if (!requestStatus.Status)
            {
                _logger.LogError($"Error: Invalid request. {requestStatus.Message}");

                return BadRequest("Invalid Request");
            }

            var getCustomersStatus = await _customerService.GetCustomersAsync(request);
            if (!getCustomersStatus.Status)
            {
                _logger.LogError($"Error: Cannot retrieve customers");

                return StatusCode((int) HttpStatusCode.InternalServerError);
            }

            return Ok(getCustomersStatus.Data);
        }
    }
}
