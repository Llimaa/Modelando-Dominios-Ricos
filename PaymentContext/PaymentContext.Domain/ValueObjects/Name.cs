using Flunt.Validations;
using PaymentContext.Shared.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentContext.Domain.ValueObjects
{
    public class Name : ValueObject
    {
        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;

            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(FirstName, 3, "Name.FirstName", "O nome deve conter no minimo 3 caractéres")
                .HasMaxLen(FirstName, 40, "Name.FirstName", "O nome deve conter no maximo 40 caractéres")

                .HasMinLen(LastName, 3, "Name.LastName", "O sobre nome deve conter no minimo 3 caractéres")
                .HasMaxLen(LastName, 40, "Name.LastName", "O sobre nome deve conter no maximo 40 caractéres")
            );
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}
