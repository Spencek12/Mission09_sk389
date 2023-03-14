using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission09_sk389.Models
{
    public interface IPaymentRepository
    {
        IQueryable<Payment> Payments { get; }

        void SavePayment(Payment payment);
    }

}
