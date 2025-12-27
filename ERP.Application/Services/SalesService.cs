using ERP.Application.Interfaces.Repositories;
using ERP.Application.Interfaces.Services;
using ERP.Contracts.Orders;
using ERP.Domain.Entities;

namespace ERP.Application.Services;

public sealed class SalesService : ISalesService
{
    private readonly ISalesRepository _repo;

    public SalesService(ISalesRepository repo)
    {
        _repo = repo;
    }

    public async Task<IReadOnlyList<SaleReceivablePayableDto>>
        GetSaleReceivablePayableAsync(string fran, string mode, CancellationToken ct)
    {
        if (string.IsNullOrWhiteSpace(fran))
            throw new ArgumentException("Fran is required");

        if (mode != "Receivable" && mode != "Payable")
            throw new ArgumentException("Invalid mode");

        return await _repo.GetSaleReceivablePayableAsync(fran, mode, ct);
    }

    // Commented by: Vaishnavi
    // Commented on: 15-12-2025

    // Headers
    //public async Task<IReadOnlyList<SaleHeaderDto>> GetAllHeadersAsync(CancellationToken ct)
    //    => (await repo.GetAllHeadersAsync(ct)).Select(ToDto).ToList();

    //public async Task<SaleHeaderDto?> GetHeaderByKeyAsync(string fran, string brch, string whse, string saleType, string saleNo, CancellationToken ct)
    //{
    //    var x = await repo.GetHeaderByKeyAsync(fran, brch, whse, saleType, saleNo, ct);
    //    return x is null ? null : ToDto(x);
    //}

    //public async Task<SaleHeaderDto> CreateHeaderAsync(CreateSaleHeaderRequest req, CancellationToken ct)
    //{
    //    var e = new SaleHeader
    //    {
    //        Fran = req.Fran,
    //        Branch = req.Branch,
    //        Warehouse = req.Warehouse,
    //        SaleType = req.SaleType,
    //        SaleNo = req.SaleNo,
    //        SaleDate = DateOnly.Parse(req.SaleDate),
    //        CustomerCode = req.CustomerCode,
    //        Currency = req.Currency,
    //        NoOfItems = req.NoOfItems,
    //        Discount = req.Discount,
    //        TotalValue = req.TotalValue,
    //        SeqNo = 0,
    //        SeqPrefix = string.Empty,
    //        SalesChannel = string.Empty,
    //        CreateDt = DateOnly.FromDateTime(DateTime.UtcNow),
    //        CreateTm = DateTime.UtcNow,
    //        CreateBy = "api",
    //        CreateRemarks = string.Empty,
    //        UpdateDt = DateOnly.FromDateTime(DateTime.UtcNow),
    //        UpdateTm = DateTime.UtcNow,
    //        UpdateBy = "api",
    //        UpdateRemarks = string.Empty,
    //    };
    //    await repo.CreateHeaderAsync(e, ct);
    //    return ToDto(e);
    //}

    //public async Task<bool> UpdateHeaderAsync(string fran, string brch, string whse, string saleType, string saleNo, UpdateSaleHeaderRequest req, CancellationToken ct)
    //{
    //    var e = await repo.GetHeaderByKeyAsync(fran, brch, whse, saleType, saleNo, ct);
    //    if (e is null) return false;
    //    e.SaleDate = req.SaleDate is null ? e.SaleDate : DateOnly.Parse(req.SaleDate);
    //    e.CustomerCode = req.CustomerCode ?? e.CustomerCode;
    //    e.Currency = req.Currency ?? e.Currency;
    //    e.NoOfItems = req.NoOfItems ?? e.NoOfItems;
    //    e.Discount = req.Discount ?? e.Discount;
    //    e.TotalValue = req.TotalValue ?? e.TotalValue;
    //    e.UpdateDt = DateOnly.FromDateTime(DateTime.UtcNow);
    //    e.UpdateTm = DateTime.UtcNow;
    //    e.UpdateBy = "api";
    //    await repo.UpdateHeaderAsync(e, ct);
    //    return true;
    //}

    //public async Task<bool> DeleteHeaderAsync(string fran, string brch, string whse, string saleType, string saleNo, CancellationToken ct)
    //{
    //    var exists = await repo.GetHeaderByKeyAsync(fran, brch, whse, saleType, saleNo, ct);
    //    if (exists is null) return false;
    //    await repo.DeleteHeaderAsync(fran, brch, whse, saleType, saleNo, ct);
    //    return true;
    //}

    //// Lines
    //public async Task<IReadOnlyList<SaleDetailDto>> GetAllLinesAsync(CancellationToken ct)
    //    => (await repo.GetAllLinesAsync(ct)).Select(ToDto).ToList();

    //public async Task<SaleDetailDto?> GetLineByKeyAsync(string fran, string brch, string whse, string saleType, string saleNo, string salesRl, CancellationToken ct)
    //{
    //    var x = await repo.GetLineByKeyAsync(fran, brch, whse, saleType, saleNo, salesRl, ct);
    //    return x is null ? null : ToDto(x);
    //}

    //public async Task<SaleDetailDto> CreateLineAsync(CreateSaleDetailRequest req, CancellationToken ct)
    //{
    //    var e = new SaleDetail
    //    {
    //        Fran = req.Fran,
    //        Branch = req.Branch,
    //        Warehouse = req.Warehouse,
    //        SaleType = req.SaleType,
    //        SaleNo = req.SaleNo,
    //        SalesRl = req.SalesRl,
    //        SaleDate = DateOnly.Parse(req.SaleDate),
    //        Make = req.Make,
    //        Part = req.Part,
    //        Qty = req.Qty,
    //        UnitPrice = req.UnitPrice,
    //        Discount = req.Discount,
    //        VatPercentage = req.VatPercentage,
    //        VatValue = req.VatValue,
    //        DiscountValue = req.DiscountValue,
    //        TotalValue = req.TotalValue,
    //        CreateDt = DateOnly.FromDateTime(DateTime.UtcNow),
    //        CreateTm = DateTime.UtcNow,
    //        CreateBy = "api",
    //        CreateRemarks = string.Empty,
    //        UpdateDt = DateOnly.FromDateTime(DateTime.UtcNow),
    //        UpdateTm = DateTime.UtcNow,
    //        UpdateBy = "api",
    //        UpdateRemarks = string.Empty,
    //    };
    //    await repo.CreateLineAsync(e, ct);
    //    return ToDto(e);
    //}

    //public async Task<bool> UpdateLineAsync(string fran, string brch, string whse, string saleType, string saleNo, string salesRl, UpdateSaleDetailRequest req, CancellationToken ct)
    //{
    //    var e = await repo.GetLineByKeyAsync(fran, brch, whse, saleType, saleNo, salesRl, ct);
    //    if (e is null) return false;
    //    e.SaleDate = req.SaleDate is null ? e.SaleDate : DateOnly.Parse(req.SaleDate);
    //    e.Make = req.Make ?? e.Make;
    //    e.Part = req.Part ?? e.Part;
    //    e.Qty = req.Qty ?? e.Qty;
    //    e.UnitPrice = req.UnitPrice ?? e.UnitPrice;
    //    e.Discount = req.Discount ?? e.Discount;
    //    e.VatPercentage = req.VatPercentage ?? e.VatPercentage;
    //    e.VatValue = req.VatValue ?? e.VatValue;
    //    e.DiscountValue = req.DiscountValue ?? e.DiscountValue;
    //    e.TotalValue = req.TotalValue ?? e.TotalValue;
    //    e.UpdateDt = DateOnly.FromDateTime(DateTime.UtcNow);
    //    e.UpdateTm = DateTime.UtcNow;
    //    e.UpdateBy = "api";
    //    await repo.UpdateLineAsync(e, ct);
    //    return true;
    //}

    //public async Task<bool> DeleteLineAsync(string fran, string brch, string whse, string saleType, string saleNo, string salesRl, CancellationToken ct)
    //{
    //    var exists = await repo.GetLineByKeyAsync(fran, brch, whse, saleType, saleNo, salesRl, ct);
    //    if (exists is null) return false;
    //    await repo.DeleteLineAsync(fran, brch, whse, saleType, saleNo, salesRl, ct);
    //    return true;
    //}

    //private static SaleHeaderDto ToDto(SaleHeader x) => new()
    //{
    //    Fran = x.Fran,
    //    Branch = x.Branch,
    //    Warehouse = x.Warehouse,
    //    SaleType = x.SaleType,
    //    SaleNo = x.SaleNo,
    //    SaleDate = x.SaleDate.ToString("yyyy-MM-dd"),
    //    CustomerCode = x.CustomerCode,
    //    Currency = x.Currency,
    //    NoOfItems = x.NoOfItems,
    //    Discount = x.Discount,
    //    TotalValue = x.TotalValue
    //};

    //private static SaleDetailDto ToDto(SaleDetail x) => new()
    //{
    //    Fran = x.Fran,
    //    Branch = x.Branch,
    //    Warehouse = x.Warehouse,
    //    SaleType = x.SaleType,
    //    SaleNo = x.SaleNo,
    //    SalesRl = x.SalesRl,
    //    SaleDate = x.SaleDate.ToString("yyyy-MM-dd"),
    //    Make = x.Make,
    //    Part = x.Part,
    //    Qty = x.Qty,
    //    UnitPrice = x.UnitPrice,
    //    Discount = x.Discount,
    //    VatPercentage = x.VatPercentage,
    //    VatValue = x.VatValue,
    //    DiscountValue = x.DiscountValue,
    //    TotalValue = x.TotalValue
    //};
}
