using Microsoft.EntityFrameworkCore;
using PaymentProcessApi.Entity.DatabaseContexts;
using PaymentProcessApi.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PaymentProcessApi.Entity.Repositories
{ 
    public class PaymentStateRepository : GenericRepository<PaymentState>, IPaymentStateRepository
    {
        public PaymentStateRepository(PaymentProcessContext dbContext) : base(dbContext)
        {

        }
        public override async Task<PaymentState> GetById(long id)
        {
            return await _dbContext.Set<PaymentState>()
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.PaymentId == id);
        }
    }
}
