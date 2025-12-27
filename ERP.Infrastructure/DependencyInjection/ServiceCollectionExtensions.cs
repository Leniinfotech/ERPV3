using System.Data;
using Microsoft.Data.SqlClient;
using Dapper;
using ERP.Application.Reporting.Interfaces;
using ERP.Application.Reporting.Interfaces.Repositories;
using ERP.Application.Interfaces.Repositories;
using ERP.Infrastructure.Persistence.Repositories;
using ERP.Application.Reporting.Services;
using ERP.Application.Abstractions.Logging;
using ERP.Infrastructure.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using ERP.Infrastructure.Persistence;

namespace ERP.Infrastructure.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration cfg)
        {
            services.AddScoped<IDbConnection>(_ => new SqlConnection(cfg.GetConnectionString("DefaultConnection")));
            services.AddDbContext<ErpDbContext>(opt =>
                opt.UseSqlServer(cfg.GetConnectionString("DefaultConnection")));
            services.AddSingleton(typeof(IAppLogger<>), typeof(AppLoggerAdapter<>));
            services.AddScoped<IPartsRepository, PartsRepository>();
            services.AddScoped<ISuppliersRepository, SuppliersRepository>();
            services.AddScoped<IInventoryLocationsRepository, InventoryLocationsRepository>();
            services.AddScoped<IPurchaseOrdersRepository, PurchaseOrdersRepository>();
            services.AddScoped<IShipmentsRepository, ShipmentsRepository>();
            services.AddScoped<IBranchesRepository, BranchesRepository>();
            services.AddScoped<IFranchisesRepository, FranchisesRepository>();
            services.AddScoped<ICurrenciesRepository, CurrenciesRepository>();
            services.AddScoped<IMakesRepository, MakesRepository>();
            services.AddScoped<IStoresRepository, StoresRepository>();
            services.AddScoped<IJournalEntriesRepository, JournalEntriesRepository>();
            services.AddScoped<IJournalEntryLinesRepository, JournalEntryLinesRepository>();
            services.AddScoped<ICustomersRepository, CustomersRepository>();
            services.AddScoped<IUsersRepository, UsersRepository>();
            services.AddScoped<IWorkshopsRepository, WorkshopsRepository>();
            services.AddScoped<ISalesRepository, SalesRepository>();
            services.AddScoped<IReceiptsRepository, ReceiptsRepository>();
            services.AddScoped<IShipmentDetailsRepository, ShipmentDetailsRepository>();
            services.AddScoped<IPackingRepository, PackingRepository>();
            services.AddScoped<ICartonsRepository, CartonsRepository>();
            
            // New repositories for full coverage
            services.AddScoped<IAuthorityRepository, AuthorityRepository>();
            services.AddScoped<ICompetitorRepository, CompetitorRepository>();
            services.AddScoped<IFinalPartRepository, FinalPartRepository>();
            services.AddScoped<ISubsPartRepository, SubsPartRepository>();
            services.AddScoped<ICustomerOrdersRepository, CustomerOrdersRepository>();
            services.AddScoped<ILoadingAdviceRepository, LoadingAdviceRepository>();
            services.AddScoped<IOrderPlanRepository, OrderPlanRepository>();
            services.AddScoped<IPriceGroupRepository, PriceGroupRepository>();
            services.AddScoped<IPatternCartonRepository, PatternCartonRepository>();
            services.AddScoped<IPoAllocationRepository, PoAllocationRepository>();
            services.AddScoped<IPoB2BRepository, PoB2BRepository>();
            services.AddScoped<IChartOfAccountsRepository, ChartOfAccountsRepository>();
            services.AddScoped<IParamsRepository, ParamsRepository>();
            
            SqlMapper.AddTypeHandler(new DateOnlyTypeHandler());
            return services;
        }

        public static IServiceCollection AddReportingInfrastructure(this IServiceCollection services, IConfiguration cfg)
        {
            services.AddScoped<IInventoryReportingRepository, ERP.Infrastructure.Reporting.Repositories.InventoryReportingRepository>();
            services.AddScoped<IInventoryReportingService, InventoryReportingService>();
            return services;
        }
    }

    internal sealed class DateOnlyTypeHandler : SqlMapper.TypeHandler<DateOnly>
    {
        public override DateOnly Parse(object value) => DateOnly.FromDateTime((DateTime)value);
        public override void SetValue(IDbDataParameter parameter, DateOnly value) => parameter.Value = value.ToDateTime(TimeOnly.MinValue);
    }
}