using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaGoF.Infrastructure.Legado
{
	public class SistemaLegadoProntuario
	{
		public DadosLegado BuscarDadosPaciente(int pacienteId)
		{
			return new DadosLegado
			{
				Historico = "Histórico médico legado do paciente " + pacienteId,
				ListaAlergias = "Nenhuma alergia registrada"
			};
		}
	}

	public class DadosLegado
	{
		public string Historico { get; set; }
		public string ListaAlergias { get; set; }
	}

}
