using ERP.Application.Interfaces.Repositories;
using ERP.Application.Interfaces.Services;
using ERP.Contracts.Orders;
using ERP.Domain.Entities;

namespace ERP.Application.Services;

public sealed class CustomerOrdersService(ICustomerOrdersRepository repo) : ICustomerOrdersService
{
    // Headers
    public async Task<IReadOnlyList<CustomerOrderHeaderDto>> GetAllHeadersAsync(CancellationToken ct)
    {
        var items = await repo.GetAllHeadersAsync(ct);
        return items.Select(MapHeaderToDto).ToList();
    }

    public async Task<CustomerOrderHeaderDto?> GetHeaderByKeyAsync(string fran, string branch, string warehouse, string cordType, string cordNo, CancellationToken ct)
    {
        var item = await repo.GetHeaderByKeyAsync(fran, branch, warehouse, cordType, cordNo, ct);
        return item is null ? null : MapHeaderToDto(item);
    }

    public async Task<CustomerOrderHeaderDto> CreateHeaderAsync(CreateCustomerOrderHeaderRequest request, CancellationToken ct)
    {
        var entity = new CustomerOrderHeader
        {
            Fran = request.Fran,
            Branch = request.Branch,
            Warehouse = request.Warehouse,
            CordType = request.CordType,
            CordNo = request.CordNo,
            CordDate = request.CordDate ?? DateOnly.FromDateTime(DateTime.UtcNow),
            Customer = request.Customer ?? string.Empty,
            SeqNo = request.SeqNo ?? 0m,
            SeqPrefix = request.SeqPrefix ?? string.Empty,
            Currency = request.Currency ?? string.Empty,
            NoOfItems = request.NoOfItems ?? 0m,
            DiscountValue = request.DiscountValue ?? 0m,
            GrossValue = request.GrossValue ?? 0m,
            NetValue = request.NetValue ?? 0m,
            VatValue = request.VatValue ?? 0m,
            TotalValue = request.TotalValue ?? 0m,
            CreateDt = DateOnly.FromDateTime(DateTime.UtcNow),
            CreateTm = DateTime.UtcNow,
            CreateBy = "SYSTEM",
            CreateRemarks = string.Empty,
            UpdateDt = DateOnly.FromDateTime(DateTime.UtcNow),
            UpdateTm = DateTime.UtcNow,
            UpdateBy = string.Empty,
            UpdateRemarks = string.Empty
        };
        var created = await repo.AddHeaderAsync(entity, ct);
        return MapHeaderToDto(created);
    }

    public async Task<CustomerOrderHeaderDto?> UpdateHeaderAsync(string fran, string branch, string warehouse, string cordType, string cordNo, UpdateCustomerOrderHeaderRequest request, CancellationToken ct)
    {
        var existing = await repo.GetHeaderByKeyAsync(fran, branch, warehouse, cordType, cordNo, ct);
        if (existing is null) return null;

        existing.CordDate = request.CordDate ?? existing.CordDate;
        existing.Customer = request.Customer ?? existing.Customer;
        existing.SeqNo = request.SeqNo ?? existing.SeqNo;
        existing.Currency = request.Currency ?? existing.Currency;
        existing.NoOfItems = request.NoOfItems ?? existing.NoOfItems;
        existing.TotalValue = request.TotalValue ?? existing.TotalValue;
        existing.UpdateDt = DateOnly.FromDateTime(DateTime.UtcNow);
        existing.UpdateTm = DateTime.UtcNow;
        existing.UpdateBy = "SYSTEM";

        var updated = await repo.UpdateHeaderAsync(existing, ct);
        return updated is null ? null : MapHeaderToDto(updated);
    }

    public Task<bool> DeleteHeaderAsync(string fran, string branch, string warehouse, string cordType, string cordNo, CancellationToken ct)
        => repo.DeleteHeaderAsync(fran, branch, warehouse, cordType, cordNo, ct);

    // Details
    public async Task<IReadOnlyList<CustomerOrderDetailDto>> GetAllDetailsAsync(CancellationToken ct)
    {
        var items = await repo.GetAllDetailsAsync(ct);
        return items.Select(MapDetailToDto).ToList();
    }

    public async Task<CustomerOrderDetailDto?> GetDetailByKeyAsync(string fran, string branch, string warehouse, string cordType, string cordNo, string cordSrl, CancellationToken ct)
    {
        var item = await repo.GetDetailByKeyAsync(fran, branch, warehouse, cordType, cordNo, cordSrl, ct);
        return item is null ? null : MapDetailToDto(item);
    }

    public async Task<CustomerOrderDetailDto> CreateDetailAsync(CreateCustomerOrderDetailRequest request, CancellationToken ct)
    {
        var entity = new CustomerOrderDetail
        {
            Fran = request.Fran,
            Branch = request.Branch,
            Warehouse = request.Warehouse,
            CordType = request.CordType,
            CordNo = request.CordNo,
            CordSrl = request.CordSrl,
            CordDate = request.CordDate ?? DateOnly.FromDateTime(DateTime.UtcNow),
            Make = request.Make ?? string.Empty,
            Part = request.Part ?? 0m,
            Qty = request.Qty ?? 0m,
            AccpQty = request.AccpQty ?? 0m,
            NotAvlQty = request.NotAvlQty ?? 0m,
            Price = request.Price ?? 0m,
            Discount = request.Discount ?? 0m,
            VatPercentage = request.VatPercentage ?? 0m,
            VatValue = request.VatValue ?? 0m,
            DiscountValue = request.DiscountValue ?? 0m,
            TotalValue = request.TotalValue ?? 0m,
            CreateDt = DateOnly.FromDateTime(DateTime.UtcNow),
            CreateTm = DateTime.UtcNow,
            CreateBy = "SYSTEM",
            CreateRemarks = string.Empty,
            UpdateDt = DateOnly.FromDateTime(DateTime.UtcNow),
            UpdateTm = DateTime.UtcNow,
            UpdateBy = string.Empty,
            UpdateRemarks = string.Empty
        };
        var created = await repo.AddDetailAsync(entity, ct);
        return MapDetailToDto(created);
    }

    public async Task<CustomerOrderDetailDto?> UpdateDetailAsync(string fran, string branch, string warehouse, string cordType, string cordNo, string cordSrl, UpdateCustomerOrderDetailRequest request, CancellationToken ct)
    {
        var existing = await repo.GetDetailByKeyAsync(fran, branch, warehouse, cordType, cordNo, cordSrl, ct);
        if (existing is null) return null;

        existing.Qty = request.Qty ?? existing.Qty;
        existing.Price = request.Price ?? existing.Price;
        existing.TotalValue = request.TotalValue ?? existing.TotalValue;
        existing.UpdateDt = DateOnly.FromDateTime(DateTime.UtcNow);
        existing.UpdateTm = DateTime.UtcNow;
        existing.UpdateBy = "SYSTEM";

        var updated = await repo.UpdateDetailAsync(existing, ct);
        return updated is null ? null : MapDetailToDto(updated);
    }

    public Task<bool> DeleteDetailAsync(string fran, string branch, string warehouse, string cordType, string cordNo, string cordSrl, CancellationToken ct)
        => repo.DeleteDetailAsync(fran, branch, warehouse, cordType, cordNo, cordSrl, ct);

    private static CustomerOrderHeaderDto MapHeaderToDto(CustomerOrderHeader e) => new(
        e.Fran, e.Branch, e.Warehouse, e.CordType, e.CordNo, e.CordDate, e.Customer, e.SeqNo, e.SeqPrefix, e.Currency,
        e.NoOfItems, e.DiscountValue, e.GrossValue, e.NetValue, e.VatValue, e.TotalValue,
        e.CreateDt, e.CreateTm, e.CreateBy);

    private static CustomerOrderDetailDto MapDetailToDto(CustomerOrderDetail e) => new(
        e.Fran, e.Branch, e.Warehouse, e.CordType, e.CordNo, e.CordSrl, e.CordDate, e.Make, e.Part, e.Qty,
        e.AccpQty, e.NotAvlQty, e.Price, e.Discount, e.VatPercentage, e.VatValue, e.DiscountValue, e.TotalValue,
        e.CreateDt, e.CreateTm, e.CreateBy);
}
