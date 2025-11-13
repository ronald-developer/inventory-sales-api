using InventorySales.Contracts;
using InventorySales.Contracts.AssetServices;
using InventorySales.Contracts.AssetTypeServices;
using InventorySales.Contracts.DataTypeServices;
using InventorySales.Contracts.ElementDefinitionServices;
using InventorySales.Contracts.ElementValueServices;
using InventorySales.Contracts.MetadataSchemaVersionServices;
using InventorySales.Contracts.Repositories;
using InventorySales.Implementations.AssetServices;
using InventorySales.Implementations.AssetTypeServices;
using InventorySales.Implementations.DataTypeServices;
using InventorySales.Implementations.ElementDefinitionServices;
using InventorySales.Implementations.ElementValueServices;
using InventorySales.Implementations.MetadataSchemaVersionServices;
using InventorySales.Implementations.Repositories;
using Microsoft.Extensions.DependencyInjection;

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

            services.AddScoped<IDataTypeEntryService, DataTypeEntryService>();
            services.AddScoped<IDataTypeDataService, DataTypeDataService>();

            services.AddScoped<IAssetEntryService, AssetEntryService>();
            services.AddScoped<IAssetDataService, AssetDataService>();

            services.AddScoped<IMetadataSchemaVersionEntryService, MetadataSchemaVersionEntryService>();
            services.AddScoped<IMetadataSchemaVersionDataService, MetadataSchemaVersionDataService>();

            services.AddScoped<IElementValueEntryService, ElementValueEntryService>();
            services.AddScoped<IElementValueDataService, ElementValueDataService>();

            services.AddScoped<IElementDefinitionEntryService, ElementDefinitionEntryService>();
            services.AddScoped<IElementDefinitionDataService, ElementDefinitionDataService>();

            services.AddScoped<IJwtManager, JwtManager>();
            services.AddScoped<IOperationContext, OperationContext>();

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            services.AddScoped<IAssetRepository, AssetRepository>();
            services.AddScoped<IAssetTypeRepository, AssetTypeRepository>();
            services.AddScoped<IDataTypeRepository, DataTypeRepository>();
            services.AddScoped<IMetadataSchemaVersionRepository, MetadataSchemaVersionRepository>();
            services.AddScoped<IElementValueRepository, ElementValueRepository>();
            services.AddScoped<IElementDefinitionRepository, ElementDefinitionRepository>();
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
