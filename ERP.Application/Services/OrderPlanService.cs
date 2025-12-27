using ERP.Application.Interfaces.Repositories;
using ERP.Application.Interfaces.Services;
using ERP.Contracts.Orders;
using ERP.Domain.Entities;

namespace ERP.Application.Services;

public sealed class OrderPlanService(IOrderPlanRepository repo) : IOrderPlanService
{
    // Headers
    public async Task<IReadOnlyList<OrderPlanHeaderDto>> GetAllHeadersAsync(CancellationToken ct)
    {
        var items = await repo.GetAllHeadersAsync(ct);
        return items.Select(MapHeaderToDto).ToList();
    }

    public async Task<OrderPlanHeaderDto?> GetHeaderByKeyAsync(string fran, string branch, string warehouse, string planType, string planNo, CancellationToken ct)
    {
        var item = await repo.GetHeaderByKeyAsync(fran, branch, warehouse, planType, planNo, ct);
        return item is null ? null : MapHeaderToDto(item);
    }

    public async Task<OrderPlanHeaderDto> CreateHeaderAsync(CreateOrderPlanHeaderRequest request, CancellationToken ct)
    {
        var entity = new OrderPlanHeader
        {
            Fran = request.Fran, Branch = request.Branch, Warehouse = request.Warehouse,
            PlanType = request.PlanType, PlanNo = request.PlanNo,
            PlanDate = request.PlanDate ?? DateTime.UtcNow, TranType = request.TranType ?? string.Empty,
            SeqNo = request.SeqNo ?? 0m, NoItems = request.NoItems ?? 0m, NetValue = request.NetValue ?? 0m,
            PlanSelection = string.Empty, PlanCalculation = string.Empty, Status = request.Status ?? string.Empty,
            CreateDt = DateOnly.FromDateTime(DateTime.UtcNow), CreateTm = DateTime.UtcNow,
            CreateBy = "SYSTEM", CreateRemarks = string.Empty,
            UpdateDt = DateOnly.FromDateTime(DateTime.UtcNow), UpdateTm = DateTime.UtcNow,
            UpdateBy = string.Empty, UpdateRemarks = string.Empty
        };
        var created = await repo.AddHeaderAsync(entity, ct);
        return MapHeaderToDto(created);
    }

    public async Task<OrderPlanHeaderDto?> UpdateHeaderAsync(string fran, string branch, string warehouse, string planType, string planNo, UpdateOrderPlanHeaderRequest request, CancellationToken ct)
    {
        var existing = await repo.GetHeaderByKeyAsync(fran, branch, warehouse, planType, planNo, ct);
        if (existing is null) return null;
        existing.Status = request.Status ?? existing.Status;
        existing.UpdateDt = DateOnly.FromDateTime(DateTime.UtcNow);
        existing.UpdateTm = DateTime.UtcNow;
        var updated = await repo.UpdateHeaderAsync(existing, ct);
        return updated is null ? null : MapHeaderToDto(updated);
    }

    public Task<bool> DeleteHeaderAsync(string fran, string branch, string warehouse, string planType, string planNo, CancellationToken ct)
        => repo.DeleteHeaderAsync(fran, branch, warehouse, planType, planNo, ct);

    // Details
    public async Task<IReadOnlyList<OrderPlanDetailDto>> GetAllDetailsAsync(CancellationToken ct)
    {
        var items = await repo.GetAllDetailsAsync(ct);
        return items.Select(MapDetailToDto).ToList();
    }

    public async Task<OrderPlanDetailDto?> GetDetailByKeyAsync(string fran, string branch, string warehouse, string planType, decimal planNo, decimal planSrl, CancellationToken ct)
    {
        var item = await repo.GetDetailByKeyAsync(fran, branch, warehouse, planType, planNo, planSrl, ct);
        return item is null ? null : MapDetailToDto(item);
    }

    public async Task<OrderPlanDetailDto> CreateDetailAsync(CreateOrderPlanDetailRequest request, CancellationToken ct)
    {
        var entity = new OrderPlanDetail
        {
            Fran = request.Fran, Branch = request.Branch, Warehouse = request.Warehouse,
            PlanType = request.PlanType, PlanNo = request.PlanNo, PlanSrl = request.PlanSrl,
            PlanDate = request.PlanDate ?? DateTime.UtcNow, Vendor = request.Vendor ?? string.Empty,
            Make = request.Make ?? string.Empty, Part = request.Part ?? string.Empty,
            Qty = request.Qty ?? 0m, UnitPrice = request.UnitPrice ?? 0m, NetValue = request.NetValue ?? 0m,
            SuggQty = 0m, SuggValue = 0m, Currency = request.Currency ?? string.Empty,
            OhQty = 0m, OoQty = 0m, PoType = string.Empty, PoNo = string.Empty, PoSrl = 0m,
            Pmc = string.Empty, FlagParent = string.Empty, SubsPart = string.Empty, FinalPart = string.Empty,
            NoReorderCode = string.Empty, StopSaleCode = string.Empty, PlanSelection = string.Empty,
            Remarks = request.Remarks ?? string.Empty,
            CreateDt = DateOnly.FromDateTime(DateTime.UtcNow), CreateTm = DateTime.UtcNow,
            CreateBy = "SYSTEM", CreateRemarks = string.Empty,
            UpdateDt = DateOnly.FromDateTime(DateTime.UtcNow), UpdateTm = DateTime.UtcNow,
            UpdateBy = string.Empty, UpdateRemarks = string.Empty
        };
        var created = await repo.AddDetailAsync(entity, ct);
        return MapDetailToDto(created);
    }

    public async Task<OrderPlanDetailDto?> UpdateDetailAsync(string fran, string branch, string warehouse, string planType, decimal planNo, decimal planSrl, UpdateOrderPlanDetailRequest request, CancellationToken ct)
    {
        var existing = await repo.GetDetailByKeyAsync(fran, branch, warehouse, planType, planNo, planSrl, ct);
        if (existing is null) return null;
        existing.Remarks = request.Remarks ?? existing.Remarks;
        existing.UpdateDt = DateOnly.FromDateTime(DateTime.UtcNow);
        existing.UpdateTm = DateTime.UtcNow;
        var updated = await repo.UpdateDetailAsync(existing, ct);
        return updated is null ? null : MapDetailToDto(updated);
    }

    public Task<bool> DeleteDetailAsync(string fran, string branch, string warehouse, string planType, decimal planNo, decimal planSrl, CancellationToken ct)
        => repo.DeleteDetailAsync(fran, branch, warehouse, planType, planNo, planSrl, ct);

    // Masters
    public async Task<IReadOnlyList<OrderPlanMasterDto>> GetAllMastersAsync(CancellationToken ct)
    {
        var items = await repo.GetAllMastersAsync(ct);
        return items.Select(MapMasterToDto).ToList();
    }

    public async Task<OrderPlanMasterDto?> GetMasterByKeyAsync(string fran, string type, string name, CancellationToken ct)
    {
        var item = await repo.GetMasterByKeyAsync(fran, type, name, ct);
        return item is null ? null : MapMasterToDto(item);
    }

    public async Task<OrderPlanMasterDto> CreateMasterAsync(CreateOrderPlanMasterRequest request, CancellationToken ct)
    {
        var entity = new OrderPlanMaster
        {
            Fran = request.Fran, Type = request.Type, Name = request.Name,
            SelectSql = request.SelectSql ?? string.Empty, FilterSql = request.FilterSql ?? string.Empty,
            GroupBySql = request.GroupBySql ?? string.Empty, OrderBySql = request.OrderBySql ?? string.Empty,
            CreateDt = DateOnly.FromDateTime(DateTime.UtcNow), CreateTm = DateTime.UtcNow,
            CreateBy = "SYSTEM", CreateRemarks = string.Empty,
            UpdateDt = DateOnly.FromDateTime(DateTime.UtcNow), UpdateTm = DateTime.UtcNow,
            UpdateBy = string.Empty, UpdateRemarks = string.Empty
        };
        var created = await repo.AddMasterAsync(entity, ct);
        return MapMasterToDto(created);
    }

    public async Task<OrderPlanMasterDto?> UpdateMasterAsync(string fran, string type, string name, UpdateOrderPlanMasterRequest request, CancellationToken ct)
    {
        var existing = await repo.GetMasterByKeyAsync(fran, type, name, ct);
        if (existing is null) return null;
        existing.SelectSql = request.SelectSql ?? existing.SelectSql;
        existing.UpdateDt = DateOnly.FromDateTime(DateTime.UtcNow);
        existing.UpdateTm = DateTime.UtcNow;
        var updated = await repo.UpdateMasterAsync(existing, ct);
        return updated is null ? null : MapMasterToDto(updated);
    }

    public Task<bool> DeleteMasterAsync(string fran, string type, string name, CancellationToken ct)
        => repo.DeleteMasterAsync(fran, type, name, ct);

    private static OrderPlanHeaderDto MapHeaderToDto(OrderPlanHeader e) => new(
        e.Fran, e.Branch, e.Warehouse, e.PlanType, e.PlanNo, e.PlanDate, e.TranType, e.SeqNo, e.NoItems, e.NetValue, e.Status,
        e.CreateDt, e.CreateTm, e.CreateBy);

    private static OrderPlanDetailDto MapDetailToDto(OrderPlanDetail e) => new(
        e.Fran, e.Branch, e.Warehouse, e.PlanType, e.PlanNo, e.PlanSrl, e.PlanDate, e.Vendor, e.Make, e.Part,
        e.Qty, e.UnitPrice, e.NetValue, e.Currency, e.Remarks, e.CreateDt, e.CreateTm, e.CreateBy);

    private static OrderPlanMasterDto MapMasterToDto(OrderPlanMaster e) => new(
        e.Id, e.Fran, e.Type, e.Name, e.SelectSql, e.FilterSql, e.GroupBySql, e.OrderBySql,
        e.CreateDt, e.CreateTm, e.CreateBy);
}
