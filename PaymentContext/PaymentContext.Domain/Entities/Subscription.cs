using Flunt.Validations;
using PaymentContext.Shared.Entities;
using System;
using System.Collections.Generic;

namespace PaymentContext.Domain.Entities
{
    public class Subscription : Entity
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

        public IReadOnlyCollection<Payment> Paiment { get { return _payments.ToArray(); } }

        public void AddPaiment(Payment payment)
        {
            AddNotifications(new Contract()
                .Requires()
                .IsGreaterThan(DateTime.Now, payment.PaidDate, "Substription.Payments", "A data de pagamento deve ser futura.")
           );

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
