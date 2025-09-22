using Asp.Versioning;
using InventorySales.Api;
using InventorySales.Api.Filters;
using InventorySales.Api.MappingProfiles;
using InventorySales.Api.Middlewares;
using InventorySales.Api.Seeders;
using InventorySales.EntityFramework;
using InventorySales.Implementations;
using InventorySales.Models.AppSettings;
using InventorySales.Models.Authorization;
using InventorySales.Models.ExceptionTypes;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;
using System.ComponentModel.DataAnnotations;
using System.Text;
using ValidationException = InventorySales.Models.ExceptionTypes.ValidationException;

var builder = WebApplication.CreateBuilder(args);

ConfigureServices(builder);

var app = builder.Build();

await ConfigureSeedData(app);

ConfigureMiddlewares(app);

app.MapControllers();

app.Run();

static void ConfigureMiddlewares(WebApplication app)
{
    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {

    }
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Inventory sales v1");
        c.RoutePrefix = string.Empty;  // <-- serve Swagger UI at root '/'
    });
    app.UseSerilogRequestLogging();


    app.UseHttpsRedirection();

    app.UseCors("AllowAll");

    app.UseAuthentication();

    app.UseAuthorization();

    app.UseMiddleware<ExceptionMiddleware>();

    app.UseMiddleware<AuthorizationMiddleware>();
}

// Add services to the container.
static void ConfigureServices(WebApplicationBuilder builder)
{
    ConfigureEfConnection(builder);

    string tokenProviderName = builder.Configuration["IdentityTokenSettings:TokenProviderName"];

    builder.Services.Configure<IdentityTokenSettings>(builder.Configuration.GetSection("IdentityTokenSettings"));

    builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("JwtSettings"));

    builder.Services.AddIdentityCore<AppUser>()
        .AddRoles<AppRole>()
        .AddTokenProvider<DataProtectorTokenProvider<AppUser>>(tokenProviderName)
        .AddEntityFrameworkStores<InventorySalesDbContext>()
        .AddDefaultTokenProviders();

    builder.Services.AddHttpContextAccessor();

    builder.Services.AddControllers((options) =>
    {
        options.Filters.Add<GlobalRequestFilter>();
    });

    AddControllersApiBehavior(builder);

    AddInventorySalesAuthorization(builder);

    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();

    AddSwaggerWithAuthentication(builder);

    builder.Services.AddApiVersioning(
                        options =>
                        {
                            options.AssumeDefaultVersionWhenUnspecified = true;
                            options.DefaultApiVersion = new ApiVersion(1, 0); // automatically maps route to v1 for routes that dont specified 1
                            options.ReportApiVersions = true;
                            options.ApiVersionReader = ApiVersionReader.Combine(
                                new QueryStringApiVersionReader("api-version"), // request template when specifying version to use via query string
                                new HeaderApiVersionReader("X-version")); // request template when specifying version to use via req header
                        })
        .AddMvc()
        .AddApiExplorer(options =>
        {
            // add the versioned api explorer, which also adds IApiVersionDescriptionProvider service
            // note: the specified format code will format the version as "'v'major[.minor][-status]"
            options.GroupNameFormat = "'v'VVV";

            // note: this option is only necessary when versioning by url segment. the SubstitutionFormat
            // can also be used to control the format of the API version in route templates
            options.SubstituteApiVersionInUrl = true;
        });

    builder.Services.AddProblemDetails();

    builder.Services.AddCors(options =>
    {
        options.AddPolicy("AllowAll", b => b.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());
    });

    builder.Services.AddMappingProfiles();

    builder.Services.AddInventorySalesServices();

    builder.Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

    }).AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ClockSkew = TimeSpan.Zero,
            ValidIssuer = builder.Configuration["JwtSettings:Issuer"],
            ValidAudience = builder.Configuration["JwtSettings:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtSettings:Key"]))
        };

    });

    builder.Host.UseSerilog((context, loggerConfiguration) => loggerConfiguration.WriteTo.Console().ReadFrom.Configuration(context.Configuration));
}

static void AddSwaggerWithAuthentication(WebApplicationBuilder builder)
{
    builder.Services.AddSwaggerGen(options =>
    {
        options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Inventory sales", Version = "v1" });

        options.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
        {
            Name = "Authorization",
            Description = @"JWT Authorization header using the Bearer scheme.",
            In = Microsoft.OpenApi.Models.ParameterLocation.Header,
            Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey,
            Scheme = "Bearer"
        });

        options.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference{ Type = ReferenceType.SecurityScheme , Id = "Bearer"},
                    Scheme = "oauth2",
                    Name="Bearer",
                    In = ParameterLocation.Header
                },
                new List<string>()
            }
        });

        options.OperationFilter<CustomApiConventionOperationFilter>();
    });
}

static void AddControllersApiBehavior(WebApplicationBuilder builder)
{
    builder.Services.AddControllers().ConfigureApiBehaviorOptions(options =>
    {
        options.InvalidModelStateResponseFactory = context =>
        {
            ValidationException problemDetails = new ValidationException(context);

            return new BadRequestObjectResult(problemDetails)
            {
                ContentTypes = { "application/problem+json", "application/problem+xml" },
                Value = new ErrorDetails
                {
                    ErrorMessage = problemDetails.Title,
                    Errors = problemDetails.Errors,
                    ErrorType = nameof(ValidationException)
                }
            };
        };
    });

}


static void AddInventorySalesAuthorization(WebApplicationBuilder builder)
{
    builder.Services.AddSingleton<IAuthorizationHandler, InventorySalesAuthorizationHandler>();

    AuthorizationPolicy defaultPolicy = new AuthorizationPolicyBuilder()
                    .AddRequirements(new MinimumRolesAuthorizationRequirement())
                    .Build();

    builder.Services.AddAuthorizationBuilder().SetDefaultPolicy(defaultPolicy);
}

static void ConfigureEfConnection(WebApplicationBuilder builder)
{
    string connectionString = builder.Configuration.GetConnectionString("InventorySalesDbConnectionString");
    builder.Services.AddDbContext<InventorySalesDbContext>(options =>
    {
        // Fix CS1061: Ensure the UseSqlServer extension method is available by adding the correct using directive
        options.UseSqlServer(connectionString);
    });
}

static async Task ConfigureSeedData(WebApplication app)
{
    // Seed user and role
    using (var scope = app.Services.CreateScope())
    {
        var userManager = scope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
        var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<AppRole>>();

        await IdentitySeeder.SeedDefaultAdminAsync(userManager, roleManager);
    }
}
