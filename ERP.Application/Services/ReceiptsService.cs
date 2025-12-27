using ERP.Application.Interfaces.Repositories;
using ERP.Application.Interfaces.Services;
using ERP.Contracts.Orders;
using ERP.Domain.Entities;

namespace ERP.Application.Services;

public sealed class ReceiptsService(IReceiptsRepository repo) : IReceiptsService
{
    // Headers
    public async Task<IReadOnlyList<ReceiptHeaderDto>> GetAllHeadersAsync(CancellationToken ct)
        => (await repo.GetAllHeadersAsync(ct)).Select(ToDto).ToList();

    public async Task<ReceiptHeaderDto?> GetHeaderByKeyAsync(string fran, string brch, string whse, string rectType, string rectNo, CancellationToken ct)
    {
        var x = await repo.GetHeaderByKeyAsync(fran, brch, whse, rectType, rectNo, ct);
        return x is null ? null : ToDto(x);
    }

    public async Task<ReceiptHeaderDto> CreateHeaderAsync(CreateReceiptHeaderRequest req, CancellationToken ct)
    {
        var e = new ReceiptHeader
        {
            Fran = req.Fran,
            Branch = req.Branch,
            Warehouse = req.Warehouse,
            ReceiptType = req.ReceiptType,
            ReceiptNo = req.ReceiptNo,
            ReceiptDate = DateOnly.Parse(req.ReceiptDate),
            NoOfItems = req.NoOfItems,
            NetValue = req.NetValue,
            Currency = req.Currency,
            Vendor = req.Vendor,
            SeqPrefix = req.SeqPrefix,
            SeqNo = req.SeqNo,
            Remarks = req.Remarks,
            Status = req.Status,
            CreateDt = DateOnly.FromDateTime(DateTime.UtcNow),
            CreateTm = DateTime.UtcNow,
            CreateBy = "api",
            CreateRemarks = string.Empty,
            UpdateDt = DateOnly.FromDateTime(DateTime.UtcNow),
            UpdateTm = DateTime.UtcNow,
            UpdateBy = "api",
            UpdateRemarks = string.Empty,
        };
        await repo.CreateHeaderAsync(e, ct);
        return ToDto(e);
    }

    public async Task<bool> UpdateHeaderAsync(string fran, string brch, string whse, string rectType, string rectNo, UpdateReceiptHeaderRequest req, CancellationToken ct)
    {
        var e = await repo.GetHeaderByKeyAsync(fran, brch, whse, rectType, rectNo, ct);
        if (e is null) return false;
        e.ReceiptDate = req.ReceiptDate is null ? e.ReceiptDate : DateOnly.Parse(req.ReceiptDate);
        e.NoOfItems = req.NoOfItems ?? e.NoOfItems;
        e.NetValue = req.NetValue ?? e.NetValue;
        e.Currency = req.Currency ?? e.Currency;
        e.Vendor = req.Vendor ?? e.Vendor;
        e.SeqPrefix = req.SeqPrefix ?? e.SeqPrefix;
        e.SeqNo = req.SeqNo ?? e.SeqNo;
        e.Remarks = req.Remarks ?? e.Remarks;
        e.Status = req.Status ?? e.Status;
        e.UpdateDt = DateOnly.FromDateTime(DateTime.UtcNow);
        e.UpdateTm = DateTime.UtcNow;
        e.UpdateBy = "api";
        await repo.UpdateHeaderAsync(e, ct);
        return true;
    }

    public async Task<bool> DeleteHeaderAsync(string fran, string brch, string whse, string rectType, string rectNo, CancellationToken ct)
    {
        var exists = await repo.GetHeaderByKeyAsync(fran, brch, whse, rectType, rectNo, ct);
        if (exists is null) return false;
        await repo.DeleteHeaderAsync(fran, brch, whse, rectType, rectNo, ct);
        return true;
    }

    // Lines
    public async Task<IReadOnlyList<ReceiptDetailDto>> GetAllLinesAsync(CancellationToken ct)
        => (await repo.GetAllLinesAsync(ct)).Select(ToDto).ToList();

    public async Task<ReceiptDetailDto?> GetLineByKeyAsync(string fran, string brch, string whse, string rectType, string rectNo, decimal rectSrl, CancellationToken ct)
    {
        var x = await repo.GetLineByKeyAsync(fran, brch, whse, rectType, rectNo, rectSrl, ct);
        return x is null ? null : ToDto(x);
    }

    public async Task<ReceiptDetailDto> CreateLineAsync(CreateReceiptDetailRequest req, CancellationToken ct)
    {
        var e = new ReceiptDetail
        {
            Fran = req.Fran,
            Branch = req.Branch,
            Warehouse = req.Warehouse,
            ReceiptType = req.ReceiptType,
            ReceiptNo = req.ReceiptNo,
            ReceiptSerial = req.ReceiptSerial,
            Make = req.Make,
            Part = req.Part,
            Qty = req.Qty,
            UnitPrice = req.UnitPrice,
            NetValue = req.NetValue,
            Currency = req.Currency,
            StoreId = req.StoreId,
            Vendor = req.Vendor,
            PoType = req.PoType,
            PoNo = req.PoNo,
            PoSrl = req.PoSrl,
            Remarks = req.Remarks,
            Status = req.Status,
            CreateDt = DateOnly.FromDateTime(DateTime.UtcNow),
            CreateTm = DateTime.UtcNow,
            CreateBy = "api",
            CreateRemarks = string.Empty,
            UpdateDt = DateOnly.FromDateTime(DateTime.UtcNow),
            UpdateTm = DateTime.UtcNow,
            UpdateBy = "api",
            UpdateRemarks = string.Empty,
        };
        await repo.CreateLineAsync(e, ct);
        return ToDto(e);
    }

    public async Task<bool> UpdateLineAsync(string fran, string brch, string whse, string rectType, string rectNo, decimal rectSrl, UpdateReceiptDetailRequest req, CancellationToken ct)
    {
        var e = await repo.GetLineByKeyAsync(fran, brch, whse, rectType, rectNo, rectSrl, ct);
        if (e is null) return false;
        e.Make = req.Make ?? e.Make;
        e.Part = req.Part ?? e.Part;
        e.Qty = req.Qty ?? e.Qty;
        e.UnitPrice = req.UnitPrice ?? e.UnitPrice;
        e.NetValue = req.NetValue ?? e.NetValue;
        e.Currency = req.Currency ?? e.Currency;
        e.StoreId = req.StoreId ?? e.StoreId;
        e.Vendor = req.Vendor ?? e.Vendor;
        e.PoType = req.PoType ?? e.PoType;
        e.PoNo = req.PoNo ?? e.PoNo;
        e.PoSrl = req.PoSrl ?? e.PoSrl;
        e.Remarks = req.Remarks ?? e.Remarks;
        e.Status = req.Status ?? e.Status;
        e.UpdateDt = DateOnly.FromDateTime(DateTime.UtcNow);
        e.UpdateTm = DateTime.UtcNow;
        e.UpdateBy = "api";
        await repo.UpdateLineAsync(e, ct);
        return true;
    }

    public async Task<bool> DeleteLineAsync(string fran, string brch, string whse, string rectType, string rectNo, decimal rectSrl, CancellationToken ct)
    {
        var exists = await repo.GetLineByKeyAsync(fran, brch, whse, rectType, rectNo, rectSrl, ct);
        if (exists is null) return false;
        await repo.DeleteLineAsync(fran, brch, whse, rectType, rectNo, rectSrl, ct);
        return true;
    }

    private static ReceiptHeaderDto ToDto(ReceiptHeader x) => new()
    {
        Fran = x.Fran,
        Branch = x.Branch,
        Warehouse = x.Warehouse,
        ReceiptType = x.ReceiptType,
        ReceiptNo = x.ReceiptNo,
        ReceiptDate = x.ReceiptDate.ToString("yyyy-MM-dd"),
        NoOfItems = x.NoOfItems,
        NetValue = x.NetValue,
        Currency = x.Currency,
        Vendor = x.Vendor,
        SeqPrefix = x.SeqPrefix,
        SeqNo = x.SeqNo,
        Remarks = x.Remarks,
        Status = x.Status
    };

    private static ReceiptDetailDto ToDto(ReceiptDetail x) => new()
    {
        Fran = x.Fran,
        Branch = x.Branch,
        Warehouse = x.Warehouse,
        ReceiptType = x.ReceiptType,
        ReceiptNo = x.ReceiptNo,
        ReceiptSerial = x.ReceiptSerial,
        Make = x.Make,
        Part = x.Part,
        Qty = x.Qty,
        UnitPrice = x.UnitPrice,
        NetValue = x.NetValue,
        Currency = x.Currency,
        StoreId = x.StoreId,
        Vendor = x.Vendor,
        PoType = x.PoType,
        PoNo = x.PoNo,
        PoSrl = x.PoSrl,
        Remarks = x.Remarks,
        Status = x.Status
    };
}
