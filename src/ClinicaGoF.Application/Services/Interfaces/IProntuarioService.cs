using ClinicaGoF.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaGoF.Application.Services.Interfaces
{
	public interface IProntuarioService
	{
		Prontuario GetProntuarioDoPaciente(int pacienteId);
	}

}
