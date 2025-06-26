using ClinicaGoF.Application.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaGoF.Application.Services.Notificacoes
{
	public class NotificacaoEmail : INotificacao
	{
		public void Enviar(string mensagem)
		{
			Console.WriteLine($"📧 Enviando e-mail: {mensagem}");
		}
	}
}
