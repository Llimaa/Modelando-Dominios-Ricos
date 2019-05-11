using Flunt.Notifications;
using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Commands.Results;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enuns;
using PaymentContext.Domain.Repositories;
using PaymentContext.Domain.Services;
using PaymentContext.Domain.ValueObjects;
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
        private readonly IEmailSevices _emailSevices;

        public SubscriptionHandler(IStudentRepository studentRepository, IEmailSevices emailSevices)
        {
            _studentRepository = studentRepository;
            _emailSevices = emailSevices;
        }
        public ICommandResult Handle(CreateBoletoSubscriptionCommnad command)
        {
            //Fail Fast Validator.
            command.validate();
            if (command.Invalid)
            {
                return new CommandResult(false, "Não foi possivel realizar sua assinatura!");
            }


            //verificar se o documento ja esta cadastrado.
            if (_studentRepository.DocumentExists(command.Document))
                AddNotification("Document", "Este documento ja esta em uso!");

            //Verificar se email esta cadastrado.
            if (_studentRepository.EmailExists(command.Email))
                AddNotification("Email", "Este e-mail ja esta em uso!");

            //Gerar os VOs 
            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document, EDocumentType.CPF);
            var email = new Email(command.Email);
            var address = new Address(command.Street, command.Numer, command.Neighborhood, command.City, command.State, command.Country, command.ZipCode);


            //Gerar Entidades.
            var student = new Student(name, document, email);
            var subscription = new Subscription(DateTime.Now.AddMonths(1));

            var payment = new BoletoPayment(
                command.BarCode,
                command.BoletoNumber,
                command.PaidDate,
                command.ExpireDate,
                command.Total,
                command.TotalPaid,
                command.Payer,
                new Document(command.PayerDocument, command.PayerDocumentType),
                address,
                email);

            //Relacionamentos.
            subscription.AddPaiment(payment);
            student.AddSubscriptio(subscription);


            //Agrupar as validacoes.
            AddNotifications(name, document, address, student, subscription, payment);

            //Checar as NOtificacoes.
            if (Valid)
                return new CommandResult(false, "Não foi possivel realizar sua assinatura");

            //Salvar as Informacoes.
            _studentRepository.CreateSubscription(student);

            //Eviar email de boas vindas.
            _emailSevices.Send(student.ToString(), student.Email.Address, "Bem vindo ao ao sistema", "Sua assinatura foi criada com sucesso");

            //Retornar as informacoes.
            return new CommandResult(true, "Assinatura realizada com sucesso");
        }
    }
}
