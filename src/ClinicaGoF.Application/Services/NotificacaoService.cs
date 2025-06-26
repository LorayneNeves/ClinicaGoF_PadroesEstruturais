using ClinicaGoF.Application.DTOs.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaGoF.Application.Services
{
	public class NotificacaoService
	{
		public void EnviarConfirmacao(PacienteViewModel paciente, DateTime dataHora)
		{
			Console.WriteLine($"Enviando notificação para {paciente.Nome} sobre a consulta em {dataHora}.");
		}

	}
}
