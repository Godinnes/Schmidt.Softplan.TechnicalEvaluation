using Microsoft.AspNetCore.Mvc;
using Schmidt.Softplan.TechnicalEvaluation.Application.Command.Responsaveis;
using Schmidt.Softplan.TechnicalEvaluation.Mediator.Interfaces;
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
        [HttpGet]
        public async Task<IActionResult> GetResponsavelAsync([FromQuery]GetResponsavelQuery request)
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
        [HttpDelete]
        public async Task<IActionResult> RemoveAsync([FromQuery]RemoveResponsavelCommand request)
        {
            await _mediator.SendAsync(request);
            return Ok();
        }
    }
}
