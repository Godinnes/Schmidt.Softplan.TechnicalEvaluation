using Microsoft.AspNetCore.Mvc;
using Schmidt.Softplan.TechnicalEvaluation.Application.Command.Responsaveis;
using Schmidt.Softplan.TechnicalEvaluation.Mediator.Abstraction;
using Schmidt.Softplan.TechnicalEvaluation.Query.Application.Query.Responsaveis;
using System.Threading.Tasks;

namespace Schmidt.Softplan.TechnicalEvaluation.Api.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class ResponsaveisController : ControllerBase
    {
        private readonly ISchmidtMediator _mediator;
        public ResponsaveisController(ISchmidtMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("Busca")]
        public async Task<IActionResult> GetAllAsync([FromQuery]GetResponsaveisQuery request)
        {
            var responsaveis = await _mediator.SendAsync(request);
            return Ok(responsaveis);
        }
        [HttpPost]
        public async Task<IActionResult> CreateNewAsync([FromBody]CreateResponsavelCommand request)
        {
            var responsavelID = await _mediator.SendAsync(request);
            return Ok(responsavelID);
        }
        [HttpPatch]
        public async Task<IActionResult> UpdateAsync([FromBody]ChangeResponsavelCommand request)
        {
            await _mediator.SendAsync(request);
            return Ok();
        }
        [HttpDelete("{ID}")]
        public async Task<IActionResult> RemoveAsync([FromRoute]RemoveResponsavelCommand request)
        {
            await _mediator.SendAsync(request);
            return Ok();
        }
    }
}
