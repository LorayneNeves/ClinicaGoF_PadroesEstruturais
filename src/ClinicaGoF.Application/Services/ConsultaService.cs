using ClinicaGoF.Application.DTOs.InputModels;
using ClinicaGoF.Application.DTOs.ViewModels;
using ClinicaGoF.Application.Services.Interfaces;
using ClinicaGoF.Domain.Entities;
using ClinicaGoF.Domain.Repository.Interfaces;

namespace ClinicaGoF.Application.Services;
public class ConsultaService : IConsultaService
{
	public Task AgendarAsync(ConsultaInputModel input)
	{
		throw new NotImplementedException();
	}

	public Consulta CriarConsulta(Paciente paciente, Guid medicoId, DateTime dataHora)
	{
		Console.WriteLine($"Criando consulta para paciente {paciente.Nome} com médico {medicoId} em {dataHora}...");
		return new Consulta
		{
			Id = Guid.NewGuid(),
			PacienteId = paciente.Id,
			MedicoId = medicoId,
			DataHora = dataHora
		};
	}

	public Task<IEnumerable<ConsultaViewModel>> ListarAsync()
	{
		throw new NotImplementedException();
	}

	public Task<IEnumerable<ConsultaViewModel>> ListarPorCrmMedicoAsync(string crm)
	{
		throw new NotImplementedException();
	}

	public Task<IEnumerable<ConsultaViewModel>> ListarPorDocumentoPacienteAsync(string documento)
	{
		throw new NotImplementedException();
	}

	public Task<IEnumerable<ConsultaViewModel>> ListarPorIntervaloAsync(DateTime inicio, DateTime fim)
	{
		throw new NotImplementedException();
	}

	public Task<IEnumerable<ConsultaViewModel>> ListarPorPacienteAsync(Guid pacienteId)
	{
		throw new NotImplementedException();
	}
}
