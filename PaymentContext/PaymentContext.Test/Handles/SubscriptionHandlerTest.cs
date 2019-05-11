using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Enuns;
using PaymentContext.Domain.Handlers;
using PaymentContext.Test.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentContext.Test.Handles
{

    [TestClass]
    public class SubscriptionHandlerTest
    {
        [TestMethod]

        public void ShoulReturnErrorWhenDOcumentExists()
        {
            var handle = new SubscriptionHandler(new FakeStudentRepository(), new FakeEmailService());
            var command = new CreateBoletoSubscriptionCommnad();
            command.FirstName = "bruce";
            command.LastName = "wayne";
            command.Document = "99999999999";
            command.Email = "hello@lima.io2";
            command.BarCode = "123456789";
            command.BoletoNumber = "123123123";
            command.PaidDate = DateTime.Now;
            command.ExpireDate = DateTime.Now.AddMonths(1);
            command.Total = 60;
            command.TotalPaid = 60;
            command.Payer = "WAYNE CORP";
            command.PayerDocument = "123456789";
            command.PayerDocumentType = EDocumentType.CPF;
            command.PayerEmail = "batma@dc.com";
            command.Street = "asdasww";
            command.Numer = "123123123";
            command.Neighborhood = "ffffff";
            command.City = "sddsfsdf";
            command.State = "sdfssd";
            command.Country = "assdfsda";
            command.ZipCode = "12345678";

            handle.Handle(command);
            Assert.AreEqual(false, handle.Valid);





        }

    }
}
