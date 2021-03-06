﻿using Flunt.Validations;
using PaymentContext.Shared.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentContext.Domain.ValueObjects
{
    public class Address : ValueObject
    {
        public Address(string street, string numer, string neighborhood, string city, string state, string country, string zipCode)
        {
            Street = street;
            Numer = numer;
            Neighborhood = neighborhood;
            City = city;
            State = state;
            Country = country;
            ZipCode = zipCode;

            AddNotifications(new Contract()
                .Requires()
                .HasMaxLen(street,40,"Adddress.Street", "O campo rua deve conter no maximo 40 Caractéres")
                .HasMinLen(street,3,"Adddress.Street", "O campo rua deve conter no minimo 3 Caractéres")
            );
        }

        public string Street { get; private set; }
        public string Numer { get; private set; }
        public string Neighborhood { get; private set; } //vinsinhaca.
        public string City { get; private set; }
        public string State { get; private set; }
        public string Country { get; private set; }
        public string ZipCode { get; private set; }
    }
}
