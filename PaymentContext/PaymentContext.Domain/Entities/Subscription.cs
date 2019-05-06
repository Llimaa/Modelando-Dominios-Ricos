﻿using PaymentContext.Shared.Entities;
using System;
using System.Collections.Generic;

namespace PaymentContext.Domain.Entities
{
    public class Subscription: Entity
    {
        private List<Payment> _payments;

        public Subscription(DateTime? expireDate)
        {
            CreateDate = DateTime.Now;
            LastUpdateDate = DateTime.Now;
            ExpireDate = expireDate;
            Active = true;
            _payments = new List<Payment>();
        }

        public DateTime CreateDate { get; private set; }
        public DateTime LastUpdateDate { get; private set; }
        public DateTime? ExpireDate { get; private set; }
        public bool Active { get; private set; }

        public IReadOnlyCollection<Payment> Paiment { get; private set; }

        public void AddPaiment(Payment payment)
        {
            _payments.Add(payment);
        }

        public void Activate()

        {
            Active = false;
            LastUpdateDate = DateTime.Now;
        }

        public void Inactivate()

        {
            Active = false;
            LastUpdateDate = DateTime.Now;
        }
    }
}
