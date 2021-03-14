using Microsoft.EntityFrameworkCore;
using PaymentProcessApi.Entity.DatabaseContexts;
using PaymentProcessApi.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PaymentProcessApi.Entity.Repositories
{
    public class PaymentRepository : GenericRepository<Payment>, IPaymentRepository
    {
        public PaymentRepository(PaymentProcessContext dbContext) : base(dbContext)
        {

        }
        public override async Task<Payment> GetById(long id)
        {
            return await _dbContext.Set<Payment>()
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.PaymentId == id);
        }
    }
}
