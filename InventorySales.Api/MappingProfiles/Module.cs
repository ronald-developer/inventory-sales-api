namespace InventorySales.Api.MappingProfiles
{
    public static class Module
    {
        public static void AddMappingProfiles(this IServiceCollection services)
        {
            services.AddAutoMapper(cfg => cfg.AddProfile<AuthManagerProfile>());
            services.AddAutoMapper(cfg => cfg.AddProfile<RoleManagerProfile>());
        }
    }
}
