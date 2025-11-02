using InventorySales.Contracts;
using InventorySales.Contracts.AssetTypeServices;
using InventorySales.Contracts.Repositories;
using InventorySales.Implementations.AssetTypeServices;
using InventorySales.Implementations.Repositories;
using InventorySales.Models.AppSettings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
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
            services.AddScoped<IAssetTypeEntryService, AssetTypeEntryService>();
            services.AddScoped<IAssetTypeDataService, AssetTypeDataService>();
            services.AddScoped<IJwtManager, JwtManager>();
            services.AddScoped<IOperationContext, OperationContext>();

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            services.AddScoped<IAssetTypeRepository, AssetTypeRepository>();
            //services.AddScoped<IExpenseCategoryService, ExpenseCategoryService>();

            //services.AddScoped<IExpenseRepository, ExpenseRepository>();
            //services.AddScoped<IExpenseService, ExpenseService>();

            //services.AddScoped<IDashboardService, DashboardService>();

            //services.AddSingleton(provider =>
            //{
            //    var configuration = provider.GetRequiredService<IConfiguration>();
            //    return new TokenValidationParameters
            //    {
            //        ValidateIssuerSigningKey = true,
            //        ValidateIssuer = true,
            //        ValidateAudience = true,
            //        ValidateLifetime = true,
            //        ClockSkew = TimeSpan.Zero,
            //        ValidIssuer = configuration["JwtSettings:Issuer"],
            //        ValidAudience =configuration["JwtSettings:Audience"],
            //        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSettings:Key"]))
            //    };
            //});
        }
    }
}
