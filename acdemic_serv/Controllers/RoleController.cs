using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using acdemic_serv.Utils;
using domain.Entities;
using domain.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace acdemic_serv.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoleController : BaseController
    {
        private readonly ILogger<RoleController> _logger;
        private readonly IServiceRole _serviceRole;

        public RoleController(IServiceRole serviceRole, ILogger<RoleController> logger)
        {
            _serviceRole = serviceRole;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            _logger.LogInformation("Getting all roles");

            var result = await _serviceRole.GetAllAsync();

            return Ok(ApiResponse<IEnumerable<Role>>.SuccessResponse(result.Data!));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            _logger.LogInformation("Getting role by id");

            var result = await _serviceRole.GetByIdAsync(id);

            if (!result.IsSuccess)
            {
                return NotFound(ApiResponse<string>.ErrorResponse(result.ErrorMessage!));
            }
            else
            {
                return Ok(ApiResponse<Role>.SuccessResponse(result.Data!));
            }
        }

        [HttpPost]
        public IActionResult Add(Role role)
        {
            throw new NotImplementedException();
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Role role)
        {
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok();
        }

    }
}