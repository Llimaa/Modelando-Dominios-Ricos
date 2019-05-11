using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Enuns;
using PaymentContext.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentContext.Test.Commands
{
    [TestClass]
    public class CreateBoletoSubstriptionCommandTests
    {
        [TestMethod]
        public void ShowlReturnErrorWhenNameIsValid()
        {
            var command = new CreateBoletoSubscriptionCommnad();
            command.FirstName = "marcos";

            Assert.AreEqual(false, command.Valid);
        }

        [TestMethod]
        public void ShowlReturnErrorWhenDocumentExists()
        {
            var command = new CreateBoletoSubscriptionCommnad();
        }
    }
}
