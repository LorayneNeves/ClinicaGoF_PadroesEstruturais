using ClinicaGoF.Application.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaGoF.Application.Services.Notificacoes
{
	public class NotificacaoComposta : INotificacao
	{
		private readonly List<INotificacao> _notificacoes = new();

		public void Adicionar(INotificacao notificacao)
		{
			_notificacoes.Add(notificacao);
		}

		public void Enviar(string mensagem)
		{
			foreach (var notificacao in _notificacoes)
			{
				notificacao.Enviar(mensagem);
			}
		}
	}
}
