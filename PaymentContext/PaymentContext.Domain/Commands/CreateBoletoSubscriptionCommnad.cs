using Flunt.Notifications;
using Flunt.Validations;
using PaymentContext.Domain.Enuns;
using PaymentContext.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentContext.Domain.Commands
{
    public class CreateBoletoSubscriptionCommnad : Notifiable, Icommand
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Document { get; set; }
        public string Email { get; set; }


        public string BarCode { get; set; }
        public string BoletoNumber { get; set; }
        public string PaymentNumber { get; set; }
        public DateTime PaidDate { get; set; }
        public DateTime ExpireDate { get; set; }
        public decimal Total { get; set; }
        public decimal TotalPaid { get; set; }
        public string Payer { get; set; }
        public string PayerDocument { get; set; }
        public EDocumentType PayerDocumentType { get; set; }
        public string PayerEmail { get; set; }

        public string Street { get; set; }
        public string Numer { get; set; }
        public string Neighborhood { get; set; } //vinsinhaca.
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }

        public void validade()
        {
            AddNotifications(new Contract()
               .Requires()
               .HasMinLen(FirstName, 3, "Name.FirstName", "O nome deve conter no minimo 3 caractéres")
               .HasMaxLen(FirstName, 40, "Name.FirstName", "O nome deve conter no maximo 40 caractéres")
               .HasMinLen(LastName, 3, "Name.LastName", "O sobre nome deve conter no minimo 3 caractéres")
               .HasMaxLen(LastName, 40, "Name.LastName", "O sobre nome deve conter no maximo 40 caractéres")
           );
        }
    }
}
