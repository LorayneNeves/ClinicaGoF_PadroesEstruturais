using ClinicaGoF.Application.DTOs.InputModels;
using ClinicaGoF.Application.Services;
using ClinicaGoF.Application.Services.Interfaces;
using ClinicaGoF.Application.Services.Notificacoes; // <- Importa o composite
using System;
using System.Threading.Tasks;

namespace ClinicaGoF.Application.Facades
{
	public class AgendamentoFacade
	{
		private readonly AgendaService _agendaService;
		private readonly IPacienteService _pacienteService;
		private readonly IConsultaService _consultaService;
		private readonly INotificacao _notificacao; // <- Composite

		public AgendamentoFacade(
			AgendaService agendaService,
			IPacienteService pacienteService,
			IConsultaService consultaService,
			INotificacao notificacao) // <- Recebe o composite
		{
			_agendaService = agendaService;
			_pacienteService = pacienteService;
			_consultaService = consultaService;
			_notificacao = notificacao;
		}

		public async Task AgendarConsultaAsync(string documentoPaciente, Guid medicoId, DateTime dataHora, string observacoes)
		{
			// 1. Verificar disponibilidade do médico
			if (!_agendaService.EstaDisponivel(medicoId, dataHora))
			{
				throw new Exception("Médico indisponível no horário selecionado.");
			}

			// 2. Obter o paciente pelo documento
			var paciente = await _pacienteService.ObterPorDocumentoAsync(documentoPaciente);
			if (paciente == null)
			{
				throw new Exception("Paciente não encontrado.");
			}

			// 3. Agendar a consulta
			var consultaInput = new ConsultaInputModel(
				paciente.Id,
				medicoId,
				dataHora,
				observacoes
			);

			await _consultaService.AgendarAsync(consultaInput);

			// 4. Enviar notificação para o paciente
			var mensagem = $"Consulta agendada para {paciente.Nome} em {dataHora:dd/MM/yyyy HH:mm}.";
			_notificacao.Enviar(mensagem); // Composite envia todas
		}
	}
}
