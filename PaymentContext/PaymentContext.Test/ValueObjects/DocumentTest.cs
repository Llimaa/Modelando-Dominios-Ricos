using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Enuns;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Test.ValueObjects
{
    [TestClass]
    public class DocumentTest
    {
        [TestMethod]
        public void ShoulReturnErrorWhenCNPJIsInvalid() //dado cnpj invalido deve retorna um error.
        {
            var doc = new Document("123", EDocumentType.CNPJ);
            Assert.IsTrue(doc.Invalid);
        }

        [TestMethod]
        public void ShoulReturnSuccessrWhenCNPJIsValid() //garanta que meu document e invalido
        {
            var doc = new Document("07002254000198", EDocumentType.CNPJ);
            Assert.IsTrue(doc.Valid);
        }

        [TestMethod]
        public void ShoulReturnErrorWhenCPFIsInvalid()
        {
            var doc = new Document("123", EDocumentType.CNPJ);
            Assert.IsTrue(doc.Invalid);
        }


        //fazer o teste com varios valores.
        [TestMethod]
        [DataTestMethod]
        [DataRow("29045670038")]
        [DataRow("29045670038")]
        [DataRow("29045670038")]
        [DataRow("29045670038")]
        public void ShoulReturnSuccessrWhenCPFIsValid(string cpf)
        {
            var doc = new Document(cpf, EDocumentType.CNPJ);
            Assert.IsTrue(doc.Valid);
        }
    }
}
