using ERP.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ERP.Infrastructure.Persistence;

public sealed class ErpDbContext(DbContextOptions<ErpDbContext> options) : DbContext(options)
{
    public DbSet<Part> Parts => Set<Part>();
    public DbSet<Supplier> Suppliers => Set<Supplier>();
    public DbSet<InventoryLocation> InventoryLocations => Set<InventoryLocation>();
    public DbSet<PurchaseOrder> PurchaseOrders => Set<PurchaseOrder>();
    public DbSet<PurchaseOrderLine> PurchaseOrderLines => Set<PurchaseOrderLine>();
    public DbSet<Shipment> Shipments => Set<Shipment>();
    public DbSet<Branch> Branches => Set<Branch>();
    public DbSet<Franchise> Franchises => Set<Franchise>();
    public DbSet<Currency> Currencies => Set<Currency>();
    public DbSet<Make> Makes => Set<Make>();
    public DbSet<Store> Stores => Set<Store>();
    public DbSet<JournalEntryHeader> JournalEntries => Set<JournalEntryHeader>();
    public DbSet<JournalEntryLine> JournalEntryLines => Set<JournalEntryLine>();
    public DbSet<Customer> Customers => Set<Customer>();
    public DbSet<UserAccount> Users => Set<UserAccount>();
    public DbSet<Workshop> Workshops => Set<Workshop>();
    public DbSet<SaleHeader> SaleHeaders => Set<SaleHeader>();
    public DbSet<SaleDetail> SaleDetails => Set<SaleDetail>();
    public DbSet<ReceiptHeader> ReceiptHeaders => Set<ReceiptHeader>();
    public DbSet<ReceiptDetail> ReceiptDetails => Set<ReceiptDetail>();
    public DbSet<ShipmentDetail> ShipmentDetails => Set<ShipmentDetail>();
    public DbSet<PackingHeader> PackingHeaders => Set<PackingHeader>();
    public DbSet<PackingDetail> PackingDetails => Set<PackingDetail>();
    public DbSet<Carton> Cartons => Set<Carton>();
    public DbSet<CartonDetail> CartonDetails => Set<CartonDetail>();
    
    // New entities
    public DbSet<Authority> Authorities => Set<Authority>();
    public DbSet<ChartOfAccounts> ChartOfAccounts => Set<ChartOfAccounts>();
    public DbSet<Competitor> Competitors => Set<Competitor>();
    public DbSet<CustomerOrderHeader> CustomerOrderHeaders => Set<CustomerOrderHeader>();
    public DbSet<CustomerOrderDetail> CustomerOrderDetails => Set<CustomerOrderDetail>();
    public DbSet<FinalPart> FinalParts => Set<FinalPart>();
    public DbSet<SubsPart> SubsParts => Set<SubsPart>();
    public DbSet<Params> Params => Set<Params>();
    public DbSet<LoadingAdviceHeader> LoadingAdviceHeaders => Set<LoadingAdviceHeader>();
    public DbSet<LoadingAdviceDetail> LoadingAdviceDetails => Set<LoadingAdviceDetail>();
    public DbSet<LoadingAdviceDetail2> LoadingAdviceDetails2 => Set<LoadingAdviceDetail2>();
    public DbSet<OrderPlanHeader> OrderPlanHeaders => Set<OrderPlanHeader>();
    public DbSet<OrderPlanDetail> OrderPlanDetails => Set<OrderPlanDetail>();
    public DbSet<OrderPlanMaster> OrderPlanMasters => Set<OrderPlanMaster>();
    public DbSet<PatternCartonHeader> PatternCartonHeaders => Set<PatternCartonHeader>();
    public DbSet<PriceGroupMaster> PriceGroupMasters => Set<PriceGroupMaster>();
    public DbSet<PriceGroupFactor> PriceGroupFactors => Set<PriceGroupFactor>();
    public DbSet<PoAllocation> PoAllocations => Set<PoAllocation>();
    public DbSet<PoB2B> PoB2Bs => Set<PoB2B>();

    // Workshop/Repair entities
    public DbSet<VehicleMaster> VehicleMasters => Set<VehicleMaster>();
    public DbSet<WorkMaster> WorkMasters => Set<WorkMaster>();
    public DbSet<EmployeeMaster> EmployeeMasters => Set<EmployeeMaster>();
    public DbSet<Appointment> Appointments => Set<Appointment>();
    public DbSet<RepairHdr> RepairHdrs => Set<RepairHdr>();
    public DbSet<RepairOrder> RepairOrders => Set<RepairOrder>();
    public DbSet<WorkInvHdr> WorkInvHdrs => Set<WorkInvHdr>();
    public DbSet<WorkInvDet> WorkInvDets => Set<WorkInvDet>();
    public DbSet<WorkshopMaster> WorkshopMasters => Set<WorkshopMaster>();


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ErpDbContext).Assembly);
    }
}