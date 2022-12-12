using Application.Contracts.Service;
using Domain.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LoanApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoanController : ControllerBase
    {
        private readonly ILoanService _service;

        public LoanController(ILoanService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> AddLoanApplication(LoanRequestModel entity)
        {
            var result = await _service.AddLoanApplication(entity);
            return Ok(result);
        }
    }
}
