using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using acdemic_serv.Utils;
using domain.DTO;
using domain.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace acdemic_serv.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InstitutionController : BaseController
    {
        private readonly ILogger<InstitutionController> _logger;
        private readonly IServiceInstitution _serviceInstitution;

        public InstitutionController(IServiceInstitution serviceInstitution, ILogger<InstitutionController> logger)
        {
            _serviceInstitution = serviceInstitution;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            _logger.LogInformation("Getting all Institutions");
            var result = await _serviceInstitution.GetAll();
            return Ok(ApiResponse<IEnumerable<InstitutionDTO>>.SuccessResponse(result.Data!));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            _logger.LogInformation("Getting Institution by id");
            var result = await _serviceInstitution.GetById(id);
            if (!result.IsSuccess)
            {
                return NotFound(ApiResponse<string>.ErrorResponse(result.ErrorMessage!));
            }
            else
            {
                return Ok(ApiResponse<InstitutionDTO>.SuccessResponse(result.Data!));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] InstitutionDTO entity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ApiResponse<string>.ErrorResponse("Invalid data"));
            }
            var result = await _serviceInstitution.Create(entity);
            if (!result.IsSuccess)
            {
                return BadRequest(ApiResponse<string>.ErrorResponse(result.ErrorMessage!));
            }
            return CreatedAtAction(nameof(GetById), new { id = result.Data!.Id }, ApiResponse<InstitutionDTO>.SuccessResponse(result.Data!));
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] InstitutionDTO entity)
        {
            _logger.LogInformation("Updating Institution with id {id} - Data: {@entity}", id, entity);
            var result = _serviceInstitution.Update(id, entity);
            if (!result.Result.IsSuccess)
            {
                return BadRequest(ApiResponse<string>.ErrorResponse(result.Result.ErrorMessage!));
            }
            return Ok(ApiResponse<InstitutionDTO>.SuccessResponse(result.Result.Data!));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _serviceInstitution.Delete(id);
            if (!result.Result.IsSuccess)
            {
                return BadRequest(ApiResponse<string>.ErrorResponse(result.Result.ErrorMessage!));
            }
            return Ok(ApiResponse<bool>.SuccessResponse(result.Result.Data!));
        }
    }
}