using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaGoF.Application.Services
{
	public class AgendaService
	{
		public bool EstaDisponivel(Guid medicoId, DateTime dataHora)
		{
			return true;
		}
	}
}
