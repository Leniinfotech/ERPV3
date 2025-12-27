using Asp.Versioning;
using Asp.Versioning.ApiExplorer;
using ERP.Api.Auth;
using ERP.Api.Middleware;
using ERP.Application.Abstractions.Logging;
using ERP.Application.Interfaces.Services;
using ERP.Application.Services;
using ERP.Infrastructure.DependencyInjection;
using ERP.Infrastructure.Logging;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
var cfg = builder.Configuration;

// Logging setup (provider-agnostic; console for now) with mode switch
builder.Logging.ClearProviders();
builder.Logging.AddSimpleConsole(o =>
{
    o.IncludeScopes = true;
    o.TimestampFormat = "yyyy-MM-ddTHH:mm:ss.fffZ ";
    o.SingleLine = true;
});
var loggingMode = cfg["Logging:Mode"];
builder.Logging.SetMinimumLevel(string.Equals(loggingMode, "Verbose", StringComparison.OrdinalIgnoreCase)
    ? LogLevel.Debug
    : LogLevel.Information);

// Controllers and API versioning
builder.Services.AddControllers();
//Added by: Vaishnavi
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

builder.Services.AddLogging();
builder.Services.AddApiVersioning(options =>
{
    options.DefaultApiVersion = new ApiVersion(1, 0);
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.ReportApiVersions = true;
}).AddApiExplorer(options =>
{
    options.GroupNameFormat = "'v'VVV"; // e.g., v1
    options.SubstituteApiVersionInUrl = true;
});

// Swagger + XML comments
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "ERP.Api", Version = "v1" });

    foreach (var xml in Directory.EnumerateFiles(AppContext.BaseDirectory, "*.xml"))
    {
        c.IncludeXmlComments(xml, includeControllerXmlComments: true);
    }

    // 🔐 Add JWT Security Definition
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Enter: Bearer {your token}"
    });

    // 🔐 Add JWT Requirement for all APIs
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});

// AuthN/Z
builder.Services.AddAuthentication(
    options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    })

    .AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = false;
        options.SaveToken = true;
        options.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidAudience = builder.Configuration["Jwt:Audience"],
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidateLifetime = true,
            ValidateTokenReplay = true,
            ValidateIssuerSigningKey = true,
            RequireExpirationTime = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };
    });
    builder.Services.AddAuthorization(options =>
    {
    options.AddPolicy("erp.api.read", policy =>
    {
        policy.RequireAuthenticatedUser();
        policy.RequireClaim("scope", "erp.api.read");
    });

    options.AddPolicy("erp.api.write", policy =>
    {
        policy.RequireAuthenticatedUser();
        policy.RequireClaim("scope", "erp.api.write");
    });
    });
// DI registrations
builder.Services.AddSingleton<IAuthorizationHandler, ScopeAuthorizationHandler>();
builder.Services.AddScoped<IPartsService, PartsService>();
builder.Services.AddScoped<ISuppliersService, SuppliersService>();
builder.Services.AddScoped<IInventoryLocationsService, InventoryLocationsService>();
builder.Services.AddScoped<IPurchaseOrdersService, PurchaseOrdersService>();
builder.Services.AddScoped<IShipmentsService, ShipmentsService>();
builder.Services.AddScoped<IBranchesService, BranchesService>();
builder.Services.AddScoped<IFranchisesService, FranchisesService>();
builder.Services.AddScoped<ICurrenciesService, CurrenciesService>();
builder.Services.AddScoped<IMakesService, MakesService>();
builder.Services.AddScoped<IStoresService, StoresService>();
builder.Services.AddSingleton(typeof(IAppLogger<>), typeof(AppLoggerAdapter<>));
builder.Services.AddSingleton<IAppLogger<ERP.Infrastructure.Persistence.Repositories.PartsRepository>, AppLoggerAdapter<ERP.Infrastructure.Persistence.Repositories.PartsRepository>>();
builder.Services.AddScoped<IJournalEntriesService, JournalEntriesService>();
builder.Services.AddScoped<IJournalEntryLinesService, JournalEntryLinesService>();
builder.Services.AddScoped<ICustomersService, CustomersService>();
builder.Services.AddScoped<IUsersService, UsersService>();
builder.Services.AddScoped<IWorkshopsService, WorkshopsService>();
builder.Services.AddScoped<ISalesService, SalesService>();
builder.Services.AddScoped<IReceiptsService, ReceiptsService>();
builder.Services.AddScoped<IShipmentDetailsService, ShipmentDetailsService>();
builder.Services.AddScoped<IPackingService, PackingService>();
builder.Services.AddScoped<ICartonsService, CartonsService>();

// New services for full coverage
builder.Services.AddScoped<IAuthorityService, AuthorityService>();
builder.Services.AddScoped<ICompetitorService, CompetitorService>();
builder.Services.AddScoped<IFinalPartService, FinalPartService>();
builder.Services.AddScoped<ISubsPartService, SubsPartService>();
builder.Services.AddScoped<ICustomerOrdersService, CustomerOrdersService>();
builder.Services.AddScoped<ILoadingAdviceService, LoadingAdviceService>();
builder.Services.AddScoped<IOrderPlanService, OrderPlanService>();
builder.Services.AddScoped<IPriceGroupService, PriceGroupService>();
builder.Services.AddScoped<IPatternCartonService, PatternCartonService>();
builder.Services.AddScoped<IPoAllocationService, PoAllocationService>();
builder.Services.AddScoped<IPoB2BService, PoB2BService>();
builder.Services.AddScoped<IChartOfAccountsService, ChartOfAccountsService>();
builder.Services.AddScoped<IParamsService, ParamsService>();

builder.Services.AddHttpContextAccessor();
builder.Services.Configure<CorrelationSettings>(cfg.GetSection("Correlation"));

// Infrastructure wiring
builder.Services.AddInfrastructure(cfg)
                .AddReportingInfrastructure(cfg);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "ERP.Api v1");
    });
}

// HTTPS/HSTS
if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
}
if (cfg.GetValue<bool>("Security:RequireHttps"))
{
    app.UseHttpsRedirection();
}

// Cross-cutting middlewares
app.UseMiddleware<CorrelationIdMiddleware>();
app.UseMiddleware<ExceptionHandlingMiddleware>();
//added by: Vaishnavi
app.UseCors("AllowAll");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();