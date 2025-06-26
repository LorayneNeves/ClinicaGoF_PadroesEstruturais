using ClinicaGoF.Application.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaGoF.Application.Services.Notificacoes
{
	public class NotificacaoComLog : INotificacao
	{
		private readonly INotificacao _notificacaoOriginal;

		public NotificacaoComLog(INotificacao notificacaoOriginal)
		{
			_notificacaoOriginal = notificacaoOriginal;
		}

		public void Enviar(string mensagem)
		{
			Console.WriteLine($"[LOG] Enviando notificação - Início: {DateTime.Now}");
			_notificacaoOriginal.Enviar(mensagem);
			Console.WriteLine($"[LOG] Enviando notificação - Fim: {DateTime.Now}");
		}
	}
}
