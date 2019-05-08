using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enuns;
using PaymentContext.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentContext.Test.Entities
{
    [TestClass]
    public class StudentTest
    {
        private readonly Name _name;
        private readonly Document _document;
        private readonly Email _email;
        private readonly Student _student;
        private readonly Subscription _subscription;
        private readonly Address _address;


        public StudentTest()
        {
            _name = new Name("batman", "Wayne");
            _document = new Document("29045670038", EDocumentType.CPF);
            _email = new Email("batman@dc.com");
            _address = new Address("Rua 1", "123123", "Bairro legal", "Gothan", "SP", "BR", "1340000000");
            _student = new Student(_name, _document, _email);
            _subscription = new Subscription(null);
        }

        [TestMethod]
        public void ShoulReturnErroWhenHadActiveSubscription()
        {
            var payment = new PayPalPayment("12345678", "123123", DateTime.Now, DateTime.Now.AddDays(5), 10, 10, "Wayne Corp", _document, _address, _email);
            _subscription.AddPaiment(payment);
            _student.AddSubscriptio(_subscription);
            _student.AddSubscriptio(_subscription);

            Assert.IsTrue(_student.Invalid);
        }

        [TestMethod]
        public void ShoulReturnErroWhenSubscriptionHasNoPayment()
        {
            _student.AddSubscriptio(_subscription);
            _student.AddSubscriptio(_subscription);

            Assert.IsTrue(_student.Invalid);
        }

        [TestMethod]
        public void ShoulReturnSuccessWhenHadNotctiveSubscription()
        {
            var payment = new PayPalPayment("12345678", "123123", DateTime.Now, DateTime.Now.AddDays(5), 10, 10, "Wayne Corp", _document, _address, _email);
            _subscription.AddPaiment(payment);
            _student.AddSubscriptio(_subscription);

            Assert.IsTrue(_student.Valid);
        }
    }
}
