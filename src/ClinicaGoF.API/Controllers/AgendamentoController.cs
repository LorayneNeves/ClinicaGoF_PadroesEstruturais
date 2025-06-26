using ClinicaGoF.Application.Facades;
using Microsoft.AspNetCore.Mvc;

namespace ClinicaGoF.API.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class AgendamentoController : ControllerBase
	{
		private readonly AgendamentoFacade _agendamentoFacade;

		public AgendamentoController(AgendamentoFacade agendamentoFacade)
		{
			_agendamentoFacade = agendamentoFacade;
		}

		[HttpPost]
		public async Task<IActionResult> AgendarConsulta([FromBody] AgendamentoRequest request)
		{
			try
			{
				await _agendamentoFacade.AgendarConsultaAsync(
					request.DocumentoPaciente,
					request.MedicoId,
					request.DataHora,
					request.Observacoes
				);

				return Ok("Consulta agendada com sucesso!");
			}
			catch (Exception ex)
			{
				return BadRequest($"Erro ao agendar: {ex.Message}");
			}
		}
	}

	public class AgendamentoRequest
	{
		public string DocumentoPaciente { get; set; } = string.Empty;
		public Guid MedicoId { get; set; }
		public DateTime DataHora { get; set; }
		public string Observacoes { get; set; } = string.Empty;
	}
}
