using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using PaymentProcessApi.Entity.Entities;

namespace PaymentProcessApi.Entity.DatabaseContexts
{
    public class PaymentProcessContext : DbContext
    {
        public PaymentProcessContext(DbContextOptions<PaymentProcessContext> options) : base(options) 
        {   
        }

        public DbSet<Payment> Payments { get; set; }
        public DbSet<PaymentState> PaymentStates { get; set; }
    }
}
