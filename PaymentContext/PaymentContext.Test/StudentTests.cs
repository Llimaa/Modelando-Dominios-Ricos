using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entities;

namespace PaymentContext.Test
{
    [TestClass]
    public class StudentTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            var subscripton = new Subscription(null);
            var student = new Student("marcos", "Lima", "12345678912", "teste@gmail.com");

            student.AddSubscriptio(subscripton);
        }
    }
}
