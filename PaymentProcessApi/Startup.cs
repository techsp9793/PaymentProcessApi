using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using PaymentProcessApi.Application;
using PaymentProcessApi.Entity.DatabaseContexts;
using PaymentProcessApi.Entity.Repositories;
using PaymentProcessApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentProcessApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            var configurationSection = Configuration.GetSection("ConnectionStrings:PaymentProcessApiConnection");
            services.AddDbContext<PaymentProcessContext>(options => options.UseSqlServer(configurationSection.Value));

            services.AddScoped<ICheapPaymentGateway, CheapPaymentGateway>();
            services.AddScoped<IExpensivePaymentGateway, ExpensivePaymentGateway>();
            services.AddScoped<IPaymentRequestService, PaymentRequestService>();
            services.AddScoped<IPaymentRepository, PaymentRepository>();
            services.AddScoped<IPaymentStateRepository, PaymentStateRepository>();
            services.AddAutoMapper(c => { c.AddProfile<Services.Map.PaymentProfile>(); c.AddProfile<Services.Map.PaymentStateProfile>(); }, typeof(Startup));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PaymentProcessApi", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PaymentProcessApi v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
