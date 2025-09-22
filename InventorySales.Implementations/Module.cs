using InventorySales.Contracts;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySales.Implementations
{
    public static class Module
    {
        public static void AddInventorySalesServices(this IServiceCollection services)
        {
            services.AddTransient<IAccountManagerService, AccountManagerService>();
            services.AddTransient<IRoleManagerService, RoleManagerService>();
            services.AddScoped<IJwtManager, JwtManager>();
            services.AddScoped<IOperationContext, OperationContext>();

            //services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            //services.AddScoped<IExpenseCategoryRepository, ExpenseCategoryRepository>();
            //services.AddScoped<IExpenseCategoryService, ExpenseCategoryService>();

            //services.AddScoped<IExpenseRepository, ExpenseRepository>();
            //services.AddScoped<IExpenseService, ExpenseService>();

            //services.AddScoped<IDashboardService, DashboardService>();
        }
    }
}
