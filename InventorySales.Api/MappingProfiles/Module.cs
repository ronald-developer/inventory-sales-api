namespace InventorySales.Api.MappingProfiles
{
    public static class Module
    {
        public static void AddMappingProfiles(this IServiceCollection services)
        {
            services.AddAutoMapper(cfg => cfg.AddProfile<AuthProfile>());
            services.AddAutoMapper(cfg => cfg.AddProfile<RoleProfile>());
            services.AddAutoMapper(cfg => cfg.AddProfile<AssetTypeProfile>());
        }
    }
}
