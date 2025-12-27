using ERP.Application.Interfaces.Repositories;
using ERP.Application.Interfaces.Services;
using ERP.Contracts.Orders;
using ERP.Domain.Entities;

namespace ERP.Application.Services;

public sealed class LoadingAdviceService(ILoadingAdviceRepository repo) : ILoadingAdviceService
{
    // Headers
    public async Task<IReadOnlyList<LoadingAdviceHeaderDto>> GetAllHeadersAsync(CancellationToken ct)
    {
        var items = await repo.GetAllHeadersAsync(ct);
        return items.Select(MapHeaderToDto).ToList();
    }

    public async Task<LoadingAdviceHeaderDto?> GetHeaderByKeyAsync(string fran, string branch, string warehouse, string laType, string laNo, CancellationToken ct)
    {
        var item = await repo.GetHeaderByKeyAsync(fran, branch, warehouse, laType, laNo, ct);
        return item is null ? null : MapHeaderToDto(item);
    }

    public async Task<LoadingAdviceHeaderDto> CreateHeaderAsync(CreateLoadingAdviceHeaderRequest request, CancellationToken ct)
    {
        var entity = new LoadingAdviceHeader
        {
            Fran = request.Fran, Branch = request.Branch, Warehouse = request.Warehouse,
            LaType = request.LaType, LaNo = request.LaNo,
            LaDate = request.LaDate ?? DateTime.UtcNow, InvType = request.InvType ?? string.Empty,
            InvNo = request.InvNo ?? string.Empty, Customer = request.Customer ?? string.Empty,
            SeqNo = request.SeqNo ?? 0m, Vessel = request.Vessel ?? string.Empty,
            PortDest = request.PortDest ?? string.Empty, Etd = request.Etd ?? DateTime.UtcNow,
            Eta = request.Eta ?? DateTime.UtcNow, LoadDate = request.LoadDate ?? DateTime.UtcNow,
            Status = request.Status ?? string.Empty, NoOfCrtn = request.NoOfCrtn ?? 0m,
            Remarks = request.Remarks ?? string.Empty,
            CreateDt = DateOnly.FromDateTime(DateTime.UtcNow), CreateTm = DateTime.UtcNow,
            CreateBy = "SYSTEM", CreateRemarks = string.Empty,
            UpdateDt = DateOnly.FromDateTime(DateTime.UtcNow), UpdateTm = DateTime.UtcNow,
            UpdateBy = string.Empty, UpdateRemarks = string.Empty
        };
        var created = await repo.AddHeaderAsync(entity, ct);
        return MapHeaderToDto(created);
    }

    public async Task<LoadingAdviceHeaderDto?> UpdateHeaderAsync(string fran, string branch, string warehouse, string laType, string laNo, UpdateLoadingAdviceHeaderRequest request, CancellationToken ct)
    {
        var existing = await repo.GetHeaderByKeyAsync(fran, branch, warehouse, laType, laNo, ct);
        if (existing is null) return null;
        existing.LaDate = request.LaDate ?? existing.LaDate;
        existing.Status = request.Status ?? existing.Status;
        existing.UpdateDt = DateOnly.FromDateTime(DateTime.UtcNow);
        existing.UpdateTm = DateTime.UtcNow;
        existing.UpdateBy = "SYSTEM";
        var updated = await repo.UpdateHeaderAsync(existing, ct);
        return updated is null ? null : MapHeaderToDto(updated);
    }

    public Task<bool> DeleteHeaderAsync(string fran, string branch, string warehouse, string laType, string laNo, CancellationToken ct)
        => repo.DeleteHeaderAsync(fran, branch, warehouse, laType, laNo, ct);

    // Details
    public async Task<IReadOnlyList<LoadingAdviceDetailDto>> GetAllDetailsAsync(CancellationToken ct)
    {
        var items = await repo.GetAllDetailsAsync(ct);
        return items.Select(MapDetailToDto).ToList();
    }

    public async Task<LoadingAdviceDetailDto?> GetDetailByKeyAsync(string fran, string branch, string warehouse, string laType, string laNo, string crtnType, string crtn, CancellationToken ct)
    {
        var item = await repo.GetDetailByKeyAsync(fran, branch, warehouse, laType, laNo, crtnType, crtn, ct);
        return item is null ? null : MapDetailToDto(item);
    }

    public async Task<LoadingAdviceDetailDto> CreateDetailAsync(CreateLoadingAdviceDetailRequest request, CancellationToken ct)
    {
        var entity = new LoadingAdviceDetail
        {
            Fran = request.Fran, Branch = request.Branch, Warehouse = request.Warehouse,
            LaType = request.LaType, LaNo = request.LaNo, CrtnType = request.CrtnType, Crtn = request.Crtn,
            DocDate = request.DocDate ?? DateTime.UtcNow, CntrNo = request.CntrNo ?? string.Empty,
            CntrDate = request.CntrDate ?? DateOnly.FromDateTime(DateTime.UtcNow),
            MsCrtn = request.MsCrtn ?? string.Empty, PackType = request.PackType ?? string.Empty,
            PackNo = request.PackNo ?? string.Empty, Customer = request.Customer ?? string.Empty,
            InvType = request.InvType ?? string.Empty, InvNo = request.InvNo ?? string.Empty,
            SubInvNo = request.SubInvNo ?? string.Empty, Status = request.Status ?? string.Empty,
            CreateDt = DateOnly.FromDateTime(DateTime.UtcNow), CreateTm = DateTime.UtcNow,
            CreateBy = "SYSTEM", CreateRemarks = string.Empty,
            UpdateDt = DateOnly.FromDateTime(DateTime.UtcNow), UpdateTm = DateTime.UtcNow,
            UpdateBy = string.Empty, UpdateRemarks = string.Empty
        };
        var created = await repo.AddDetailAsync(entity, ct);
        return MapDetailToDto(created);
    }

    public async Task<LoadingAdviceDetailDto?> UpdateDetailAsync(string fran, string branch, string warehouse, string laType, string laNo, string crtnType, string crtn, UpdateLoadingAdviceDetailRequest request, CancellationToken ct)
    {
        var existing = await repo.GetDetailByKeyAsync(fran, branch, warehouse, laType, laNo, crtnType, crtn, ct);
        if (existing is null) return null;
        existing.Status = request.Status ?? existing.Status;
        existing.UpdateDt = DateOnly.FromDateTime(DateTime.UtcNow);
        existing.UpdateTm = DateTime.UtcNow;
        var updated = await repo.UpdateDetailAsync(existing, ct);
        return updated is null ? null : MapDetailToDto(updated);
    }

    public Task<bool> DeleteDetailAsync(string fran, string branch, string warehouse, string laType, string laNo, string crtnType, string crtn, CancellationToken ct)
        => repo.DeleteDetailAsync(fran, branch, warehouse, laType, laNo, crtnType, crtn, ct);

    // Detail2
    public async Task<IReadOnlyList<LoadingAdviceDetail2Dto>> GetAllDetails2Async(CancellationToken ct)
    {
        var items = await repo.GetAllDetails2Async(ct);
        return items.Select(MapDetail2ToDto).ToList();
    }

    public async Task<LoadingAdviceDetail2Dto?> GetDetail2ByKeyAsync(string fran, string branch, string warehouse, string invType, string invNo, decimal invSrl, CancellationToken ct)
    {
        var item = await repo.GetDetail2ByKeyAsync(fran, branch, warehouse, invType, invNo, invSrl, ct);
        return item is null ? null : MapDetail2ToDto(item);
    }

    public async Task<LoadingAdviceDetail2Dto> CreateDetail2Async(CreateLoadingAdviceDetail2Request request, CancellationToken ct)
    {
        var entity = new LoadingAdviceDetail2
        {
            Fran = request.Fran, Branch = request.Branch, Warehouse = request.Warehouse,
            InvType = request.InvType, InvNo = request.InvNo, InvSrl = request.InvSrl,
            InvDate = request.InvDate ?? DateOnly.FromDateTime(DateTime.UtcNow),
            Customer = request.Customer ?? string.Empty, Part = request.Part ?? string.Empty,
            Make = request.Make ?? string.Empty, Qty = request.Qty ?? 0m,
            UnitRate = request.UnitRate ?? 0m, NetValue = request.NetValue ?? 0m,
            Currency = request.Currency ?? string.Empty, Status = request.Status ?? string.Empty,
            CurrencyFactor = 0m, UnitGrossWeight = 0m, UnitNetWeight = 0m,
            LaType = string.Empty, LaNo = string.Empty, LaSrl = 0m, PackNo = string.Empty,
            PickNo = 0m, Crtn = string.Empty, Coo = string.Empty, HsCode = string.Empty,
            Width = 0m, Height = 0m, Volume = 0m, NetWeight = 0m, GrossWeight = 0m,
            KeyInGrossWeight = 0m, StoreId = string.Empty,
            CreateDt = DateOnly.FromDateTime(DateTime.UtcNow), CreateTm = DateTime.UtcNow,
            CreateBy = "SYSTEM", CreateRemarks = string.Empty,
            UpdateDt = DateOnly.FromDateTime(DateTime.UtcNow), UpdateTm = DateTime.UtcNow,
            UpdateBy = string.Empty, UpdateRemarks = string.Empty
        };
        var created = await repo.AddDetail2Async(entity, ct);
        return MapDetail2ToDto(created);
    }

    public async Task<LoadingAdviceDetail2Dto?> UpdateDetail2Async(string fran, string branch, string warehouse, string invType, string invNo, decimal invSrl, UpdateLoadingAdviceDetail2Request request, CancellationToken ct)
    {
        var existing = await repo.GetDetail2ByKeyAsync(fran, branch, warehouse, invType, invNo, invSrl, ct);
        if (existing is null) return null;
        existing.Status = request.Status ?? existing.Status;
        existing.UpdateDt = DateOnly.FromDateTime(DateTime.UtcNow);
        existing.UpdateTm = DateTime.UtcNow;
        var updated = await repo.UpdateDetail2Async(existing, ct);
        return updated is null ? null : MapDetail2ToDto(updated);
    }

    public Task<bool> DeleteDetail2Async(string fran, string branch, string warehouse, string invType, string invNo, decimal invSrl, CancellationToken ct)
        => repo.DeleteDetail2Async(fran, branch, warehouse, invType, invNo, invSrl, ct);

    private static LoadingAdviceHeaderDto MapHeaderToDto(LoadingAdviceHeader e) => new(
        e.Fran, e.Branch, e.Warehouse, e.LaType, e.LaNo, e.LaDate, e.InvType, e.InvNo, e.Customer, e.SeqNo,
        e.Vessel, e.PortDest, e.Etd, e.Eta, e.LoadDate, e.Status, e.NoOfCrtn, e.Remarks,
        e.CreateDt, e.CreateTm, e.CreateBy);

    private static LoadingAdviceDetailDto MapDetailToDto(LoadingAdviceDetail e) => new(
        e.Fran, e.Branch, e.Warehouse, e.LaType, e.LaNo, e.CrtnType, e.Crtn, e.DocDate, e.CntrNo, e.CntrDate,
        e.MsCrtn, e.PackType, e.PackNo, e.Customer, e.InvType, e.InvNo, e.SubInvNo, e.Status,
        e.CreateDt, e.CreateTm, e.CreateBy);

    private static LoadingAdviceDetail2Dto MapDetail2ToDto(LoadingAdviceDetail2 e) => new(
        e.Fran, e.Branch, e.Warehouse, e.InvType, e.InvNo, e.InvSrl, e.InvDate, e.Customer, e.Part, e.Make,
        e.Qty, e.UnitRate, e.NetValue, e.Currency, e.Status, e.CreateDt, e.CreateTm, e.CreateBy);
}
