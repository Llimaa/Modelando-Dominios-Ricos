using Flunt.Notifications;
using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Commands.Results;
using PaymentContext.Domain.Repositories;
using PaymentContext.Shared.Commands;
using PaymentContext.Shared.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentContext.Domain.Handlers
{
    public class SubscriptionHandler : Notifiable,
        IHandlers<CreateBoletoSubscriptionCommnad>
    {
        private readonly IStudentRepository _studentRepository;
        public ICommandResult Handle(CreateBoletoSubscriptionCommnad command)
        {
            //verificar se o documento ja esta cadastrado.

            //Verificar se email esta cadastrado.

            //Gerar os VOs 

            //Gerar Entidades.

            //Aplicar as validacoes.

            //Salvar as Informacoes.

            //Eviar email de boas vindas.

            //Retornar as informacoes.
            return new CommandResult(true, "Assinatura realizada com sucesso");
        }
    }
}
