using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enuns;
using PaymentContext.Domain.Queries;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Test.Queries
{
    [TestClass]
    public class StudentQueriesTest
    {
        private IList<Student> _student;

        public StudentQueriesTest()
        {
            for (var i = 0; i <= 10; i++)
            {
                _student.Add(new Student
                    (
                    new Name("marcos", i.ToString()),
                     new Document("12345678912" + i.ToString(), EDocumentType.CPF),
                    new Email(i.ToString() + "hello@lima.io2")
                    ));
            }
        }

        [TestMethod]
        public void ShoulReturnErrorWhenDocumentExist()
        {
            var exp = StudentQueries.GetStudentInfo("12345678912");
            var studh = _student.AsQueryable().Where(exp).FirstOrDefault();

            Assert.AreEqual(null, studh);
        }


        [TestMethod]
        public void ShoulReturnErrorWhenDocumenNottExist()
        {
            var exp = StudentQueries.GetStudentInfo("12345678912");
            var studh = _student.AsQueryable().Where(exp).FirstOrDefault();

            Assert.AreNotEqual(null, studh);
        }
    }
}
