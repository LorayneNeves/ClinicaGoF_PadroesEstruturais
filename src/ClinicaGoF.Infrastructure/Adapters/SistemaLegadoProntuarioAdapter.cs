using ClinicaGoF.Application.Services.Interfaces;
using ClinicaGoF.Domain.Entities;
using ClinicaGoF.Infrastructure.Legado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaGoF.Infrastructure.Adapters
{
	public class SistemaLegadoProntuarioAdapter : IProntuarioService
	{
		private readonly SistemaLegadoProntuario _sistemaLegado;

		public SistemaLegadoProntuarioAdapter(SistemaLegadoProntuario sistemaLegado)
		{
			_sistemaLegado = sistemaLegado;
		}

		public Prontuario GetProntuarioDoPaciente(int pacienteId)
		{
			// Chama o método do sistema legado
			var dadosLegado = _sistemaLegado.BuscarDadosPaciente(pacienteId);

			// Faz o mapeamento dos dados para o formato Prontuario (padrão do sistema atual)
			return new Prontuario
			{
				Historico = dadosLegado.Historico,
				Alergias = dadosLegado.ListaAlergias
			};
		}
	}

}
