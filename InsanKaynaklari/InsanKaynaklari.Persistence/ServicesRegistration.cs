using InsanKaynaklari.Application;
using InsanKaynaklari.Application.Interfaces;
using InsanKaynaklari.Application.Interfaces.Repositories.PersonnelExpenseRepo;
using InsanKaynaklari.Application.Interfaces.Repositories.UserRepo;
using InsanKaynaklari.Domain.EMailManagement.Configuration;
using InsanKaynaklari.Domain.EMailManagement.Service;
using InsanKaynaklari.Domain.Identity;
using InsanKaynaklari.Persistence.Concretes;
using InsanKaynaklari.Persistence.Context;
using InsanKaynaklari.Persistence.Repositories;
using InsanKaynaklari.Persistence.Repositories.PersonnelExpenseRepo;
using InsanKaynaklari.Persistence.Repositories.UserRepo;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


namespace InsanKaynaklari.Persistence
{
    public static class ServicesRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            // service ekleme olaylari bu katmanda yapilacaktir.
            services.AddScoped<IUserReadRepository, UserReadRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IExpenseService, ExpenseService>();

            services.AddScoped<IUserWriteRepository, UserWriteRepository>();
            services.AddScoped<IUserAuthenticationService, UserAuthenticationService>();

            services.AddScoped<IExpenseWriteRepository, ExpenseWriteRepository>();
            services.AddScoped<IExpenseReadRepository, ExpenseReadRepository>();
            services.AddDbContext<InsanKaynaklariDb>(options => options.UseSqlServer(Settings.ConnString));
            
            

        }
    }
}
