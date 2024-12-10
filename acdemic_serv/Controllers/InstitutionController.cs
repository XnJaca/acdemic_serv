using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using acdemic_serv.Utils;
using domain.DTO;
using domain.Services.Interfaces;
using domain.Utils;
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
        public async Task<IActionResult> GetAll([FromQuery] Filter filter, string? search)
        {
            _logger.LogInformation("Getting all Institutions");
            var result = await _serviceInstitution.GetAll(filter, search);
            return Ok(ApiResponse<IEnumerable<InstitutionDTO>>.SuccessResponse(result.Data!));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            _logger.LogInformation("Getting Institution by id");
            var result = await _serviceInstitution.GetById(id);

            return result.Fold<IActionResult>(
                (success) => Ok(ApiResponse<InstitutionDTO>.SuccessResponse(success)),
                (error) => NotFound(ApiResponse<string>.ErrorResponse(error))
            );
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
            return CreatedAtAction(nameof(GetById), new { id = result.Data!.Id },
                                    ApiResponse<InstitutionDTO>.SuccessResponse(result.Data!));
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

        [HttpPost("{id}/director/{directorId}")]
        public async Task<IActionResult> AssignDirector(int id, int directorId)
        {
            var result = await _serviceInstitution.AssignDirector(id, directorId);

            return result.Fold<IActionResult>(
                (success) => Ok(ApiResponse<InstitutionDTO>.SuccessResponse(success)),
                (error) => BadRequest(ApiResponse<string>.ErrorResponse(error))
            );
        }
    }
}