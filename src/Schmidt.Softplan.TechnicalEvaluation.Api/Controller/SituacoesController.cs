using Microsoft.AspNetCore.Mvc;
using Schmidt.Softplan.TechnicalEvaluation.Mediator.Abstraction;
using Schmidt.Softplan.TechnicalEvaluation.Query.Application.Query.Situacoes;
using System.Threading.Tasks;

namespace Schmidt.Softplan.TechnicalEvaluation.Api.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class SituacoesController : ControllerBase
    {
        private readonly ISchmidtMediator _mediator;
        public SituacoesController(ISchmidtMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("Busca")]
        public async Task<IActionResult> SearchAsync([FromQuery]GetSituacoesQuery request)
        {
            var situacaoes = await _mediator.SendAsync(request);
            return Ok(situacaoes);
        }
    }
}
