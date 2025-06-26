using ClinicaGoF.Application.DTOs.InputModels;
using ClinicaGoF.Application.DTOs.ViewModels;
using ClinicaGoF.Application.Services.Interfaces;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaGoF.Application.Services.Proxies
{
	public class ConsultaServiceProxy : IConsultaService
	{
		private readonly IConsultaService _consultaServiceReal;

		private readonly ConcurrentDictionary<string, IEnumerable<ConsultaViewModel>> _cacheDocumento = new();
		private readonly ConcurrentDictionary<string, IEnumerable<ConsultaViewModel>> _cacheCRM = new();

		public ConsultaServiceProxy(IConsultaService consultaServiceReal)
		{
			_consultaServiceReal = consultaServiceReal;
		}

		public Task<IEnumerable<ConsultaViewModel>> ListarAsync()
		{
			return _consultaServiceReal.ListarAsync();
		}

		public Task<IEnumerable<ConsultaViewModel>> ListarPorPacienteAsync(Guid pacienteId)
		{
			return _consultaServiceReal.ListarPorPacienteAsync(pacienteId);
		}

		public async Task<IEnumerable<ConsultaViewModel>> ListarPorDocumentoPacienteAsync(string documento)
		{
			if (_cacheDocumento.TryGetValue(documento, out var cache))
			{
				Console.WriteLine("Retornando dados do cache por documento.");
				return cache;
			}

			var resultado = await _consultaServiceReal.ListarPorDocumentoPacienteAsync(documento);
			_cacheDocumento[documento] = resultado;
			return resultado;
		}

		public async Task<IEnumerable<ConsultaViewModel>> ListarPorCrmMedicoAsync(string crm)
		{
			if (_cacheCRM.TryGetValue(crm, out var cache))
			{
				Console.WriteLine("Retornando dados do cache por CRM.");
				return cache;
			}

			var resultado = await _consultaServiceReal.ListarPorCrmMedicoAsync(crm);
			_cacheCRM[crm] = resultado;
			return resultado;
		}

		public Task<IEnumerable<ConsultaViewModel>> ListarPorIntervaloAsync(DateTime inicio, DateTime fim)
		{
			return _consultaServiceReal.ListarPorIntervaloAsync(inicio, fim);
		}

		public async Task AgendarAsync(ConsultaInputModel input)
		{
			// Pode limpar o cache ao criar uma nova consulta para manter os dados atualizados
			_cacheDocumento.Clear();
			_cacheCRM.Clear();

			await _consultaServiceReal.AgendarAsync(input);
		}
	}
}
