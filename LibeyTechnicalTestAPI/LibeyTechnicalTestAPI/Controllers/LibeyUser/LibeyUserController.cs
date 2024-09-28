using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.DTO;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
namespace LibeyTechnicalTestAPI.Controllers.LibeyUser
{
    [ApiController]
    [Route("[controller]")]
    public class LibeyUserController : Controller
    {
        private readonly ILibeyUserAggregate _aggregate;
        public LibeyUserController(ILibeyUserAggregate aggregate)
        {
            _aggregate = aggregate;
        }

        [HttpGet]
        [Route("{documentNumber}")]
        public async Task<ActionResult<LibeyUserResponse>> FindResponse(string documentNumber, CancellationToken cancellationToken)
        {
            return Ok(await _aggregate.FindResponse(documentNumber, cancellationToken));
        }

        [HttpGet]
        public async Task<ActionResult<LibeyUserResponse>> GetAll(CancellationToken cancellationToken)
        {
            return Ok(await _aggregate.GetAllResponse(cancellationToken));
        }

        [HttpGet("Filter")]
        public async Task<ActionResult<LibeyUserResponse>> GetAllFilterResponse(CancellationToken cancellationToken, string textFilter = "")
        {
            return Ok(await _aggregate.GetAllFilterResponse(textFilter, cancellationToken));
        }

        [HttpPost]
        public async Task<ActionResult<LibeyUserResponse>> Create(UserUpdateorCreateCommand command, CancellationToken cancellationToken)
        {
            return Ok(await _aggregate.Create(command, cancellationToken));
        }

        [HttpPut]
        public async Task<ActionResult<LibeyUserResponse>> Update(UserUpdateorCreateCommand command, CancellationToken cancellationToken)
        {
            return Ok(await _aggregate.Update(command, cancellationToken));
        }


        [HttpDelete]
        public async Task<ActionResult<LibeyUserResponse>> Delete(string documentNumber, CancellationToken cancellationToken)
        {
            return Ok(await _aggregate.Delete(documentNumber, cancellationToken));
        }
    }
}