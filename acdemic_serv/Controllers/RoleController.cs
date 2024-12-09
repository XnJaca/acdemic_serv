
using acdemic_serv.Utils;
using domain.DTO;
using domain.Services.Interfaces;
using domain.Utils; 
using Microsoft.AspNetCore.Mvc;

namespace acdemic_serv.Controllers {
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
        public async Task<IActionResult> GetAll([FromQuery] Filter filter, string? search )
        {
            _logger.LogInformation("Getting all roles");

            var result = await _serviceRole.GetAll(filter, search);

            return Ok(ApiResponse<IEnumerable<RoleDTO>>.SuccessResponse(result.Data!));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            _logger.LogInformation("Getting role by id");

            var result = await _serviceRole.GetById(id);

           return result.Fold<IActionResult>(
                ( success ) => Ok(ApiResponse<RoleDTO>.SuccessResponse(success)),
                ( error ) => NotFound(ApiResponse<string>.ErrorResponse(error))
           );  
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] RoleDTO role)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ApiResponse<string>.ErrorResponse("Invalid data"));
            }
            var result = await _serviceRole.Create(role);

            if (!result.IsSuccess)
            {
                return BadRequest(ApiResponse<string>.ErrorResponse(result.ErrorMessage!));
            }

            return CreatedAtAction(nameof(GetById), new { id = result.Data!.Id },
                                            ApiResponse<RoleDTO>.SuccessResponse(result.Data!));
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] RoleDTO role)
        {

            _logger.LogInformation("Updating role with id {id} - Data: {@role}", id, role);

            var result = _serviceRole.Update(id, role);

            if (!result.Result.IsSuccess)
            {
                return BadRequest(ApiResponse<string>.ErrorResponse(result.Result.ErrorMessage!));
            }

            return Ok(ApiResponse<RoleDTO>.SuccessResponse(result.Result.Data!));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _serviceRole.Delete(id);

            if (!result.Result.IsSuccess)
            {
                return BadRequest(ApiResponse<string>.ErrorResponse(result.Result.ErrorMessage!));
            }

            return Ok(ApiResponse<bool>.SuccessResponse(result.Result.Data!));
        }

    }
}