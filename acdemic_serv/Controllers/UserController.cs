using acdemic_serv.Utils;
using domain.Services.Interfaces;
using Microsoft.AspNetCore.Mvc; 
using domain.DTO.User;

namespace acdemic_serv.Controllers {
    [ApiController]
    [Route("api/[controller]")]
    public class UserController  : BaseController {

        private readonly ILogger<UserController> _logger   ;
        private readonly IServiceUser _serviceUser    ;

        public UserController ( IServiceUser serviceUser, ILogger<UserController> logger ) {
            _serviceUser = serviceUser;
            _logger = logger;
        }

        // GET api/<UserController>
        [HttpGet]
        public async Task<IActionResult> GetAll () {
            throw new NotImplementedException();
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById ( int id ) {
            throw new NotImplementedException();
        }
         
        [HttpPost] 
        [ProducesResponseType(typeof(CreateUser), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ServiceFilter(typeof(ValidationFilter<CreateUser>))]
        public async Task<IActionResult> Add ( [FromBody] CreateUser data ) {

            if ( !ModelState.IsValid ) {
                return BadRequest(ApiResponse<string>.ErrorResponse("Invalid data"));
            }

            var result = await _serviceUser.Create(data);

            if ( !result.IsSuccess ) {
                return BadRequest(ApiResponse<string>.ErrorResponse(result.ErrorMessage!));
            }

            return CreatedAtAction(nameof(GetById), new {
                id = result.Data!.Id
            }, 
                ApiResponse<CreateUser>.SuccessResponse(result.Data!)
            );
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")] 
        [ServiceFilter(typeof(ValidationFilter<UpdateUser>))]
        public async Task<IActionResult> Put ( int id, [FromBody] UpdateUser data ) {
             
            //var result = await _serviceUser.Update(data);

            //if ( !result.IsSuccess ) {
            //    return BadRequest(ApiResponse<string>.ErrorResponse(result.ErrorMessage!));
            //}

            return CreatedAtAction(nameof(GetById), new {
                id = 312123
            }, 
                ApiResponse<string>.SuccessResponse("Success") 
            );
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete ( int id ) {
        }
    }
}
