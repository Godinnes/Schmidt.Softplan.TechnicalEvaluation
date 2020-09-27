using Microsoft.AspNetCore.Mvc;
using Schmidt.Softplan.TechnicalEvaluation.Application.Command.Processos;
using Schmidt.Softplan.TechnicalEvaluation.Mediator.Interfaces;
using Schmidt.Softplan.TechnicalEvaluation.Query.Application.Query.Processos;
using System.Threading.Tasks;

namespace Schmidt.Softplan.TechnicalEvaluation.Api.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class ProcessosController : ControllerBase
    {
        private readonly ISchmidtMediator _mediator;
        public ProcessosController(ISchmidtMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("Busca")]
        public async Task<IActionResult> GetAllAsync([FromQuery]GetProcessosQuery request)
        {
            var processos = await _mediator.SendAsync(request);
            return Ok(processos);
        }
        [HttpPost]
        public async Task<IActionResult> CreateNewAsync([FromBody]CreateProcessoCommand request)
        {
            var processoID = await _mediator.SendAsync(request);
            return Ok(processoID);
        }
        [HttpPatch]
        public async Task<IActionResult> UpdateAsync([FromBody]ChangeProcessoCommand request)
        {
            await _mediator.SendAsync(request);
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveAsync([FromQuery]RemoveProcessoCommand request)
        {
            await _mediator.SendAsync(request);
            return Ok();
        }
    }
}
