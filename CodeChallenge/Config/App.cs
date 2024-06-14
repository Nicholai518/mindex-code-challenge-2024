using System;
using CodeChallenge.Data;
using CodeChallenge.Repositories;
using CodeChallenge.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CodeChallenge.Config
{
    public class App
    {
        private EmployeeContext _employeeContext;
        private CompensationContext _compensationContext;

        public WebApplication Configure(string[] args)
        {
            args ??= Array.Empty<string>();

            var builder = WebApplication.CreateBuilder(args);

            builder.UseEmployeeDB();
            builder.UseCompensationDB();

            AddServices(builder.Services);

            var env = builder.Environment;

            if (env.IsDevelopment())
            {
                SeedEmployeeDB();
                LoadCompensationDB();

                // ensure there is never more than one EmployeeContext
                // creating new EmployeeContext resulted in in-memory bug with DirectReports
                builder.Services.AddSingleton(x => _employeeContext);
                builder.Services.AddSingleton(x => _compensationContext);
            }

            var app = builder.Build();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthorization();

            app.MapControllers();

            return app;
        }

        private void AddServices(IServiceCollection services)
        {
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IEmployeeRepository, EmployeeRespository>();
            services.AddScoped<ICompensationService, CompensationService>();
            services.AddScoped<ICompensationRepository, CompensationRepository>();

            services.AddControllers();
        }

        private void SeedEmployeeDB()
        {
            _employeeContext = new EmployeeContext(
                new DbContextOptionsBuilder<EmployeeContext>()
                    .UseInMemoryDatabase("EmployeeDB").Options
            );
            new EmployeeDataSeeder(_employeeContext).Seed().Wait();
        }

        private void LoadCompensationDB()
        {
            _compensationContext = new CompensationContext(
                new DbContextOptionsBuilder<CompensationContext>()
                    .UseInMemoryDatabase("CompensationDB").Options
            );
        }
    }
}