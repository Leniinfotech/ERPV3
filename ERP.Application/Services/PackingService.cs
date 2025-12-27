using ERP.Application.Interfaces.Repositories;
using ERP.Application.Interfaces.Services;
using ERP.Contracts.Inventory;
using ERP.Domain.Entities;

namespace ERP.Application.Services;

public sealed class PackingService(IPackingRepository repo) : IPackingService
{
    // Headers
    public async Task<IReadOnlyList<PackingHeaderDto>> GetAllHeadersAsync(CancellationToken ct)
        => (await repo.GetAllHeadersAsync(ct)).Select(ToDto).ToList();

    public async Task<PackingHeaderDto?> GetHeaderByKeyAsync(string fran, string brch, string whse, string packType, string packNo, CancellationToken ct)
    {
        var e = await repo.GetHeaderByKeyAsync(fran, brch, whse, packType, packNo, ct);
        return e is null ? null : ToDto(e);
    }

    public async Task<PackingHeaderDto> CreateHeaderAsync(CreatePackingHeaderRequest req, CancellationToken ct)
    {
        var e = new PackingHeader
        {
            Fran = req.Fran,
            Branch = req.Branch,
            Warehouse = req.Warehouse,
            PackType = req.PackType,
            PackNo = req.PackNo,
            PackDate = DateOnly.Parse(req.PackDate),
            Customer = req.Customer,
            Currency = req.Currency,
            CurrFactor = req.CurrFactor,
            DespFactor = req.DespFactor,
            NoOfCrtn = req.NoOfCrtn,
            GrossValue = req.GrossValue,
            NetValue = req.NetValue,
            NetWeight = req.NetWeight,
            GrossWeight = req.GrossWeight,
            SeqPrefix = req.SeqPrefix,
            SeqNo = req.SeqNo,
            NoOfItems = req.NoOfItems,
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

    public async Task<bool> UpdateHeaderAsync(string fran, string brch, string whse, string packType, string packNo, UpdatePackingHeaderRequest req, CancellationToken ct)
    {
        var e = await repo.GetHeaderByKeyAsync(fran, brch, whse, packType, packNo, ct);
        if (e is null) return false;
        e.PackDate = req.PackDate is null ? e.PackDate : DateOnly.Parse(req.PackDate);
        e.Customer = req.Customer ?? e.Customer;
        e.Currency = req.Currency ?? e.Currency;
        e.CurrFactor = req.CurrFactor ?? e.CurrFactor;
        e.DespFactor = req.DespFactor ?? e.DespFactor;
        e.NoOfCrtn = req.NoOfCrtn ?? e.NoOfCrtn;
        e.GrossValue = req.GrossValue ?? e.GrossValue;
        e.NetValue = req.NetValue ?? e.NetValue;
        e.NetWeight = req.NetWeight ?? e.NetWeight;
        e.GrossWeight = req.GrossWeight ?? e.GrossWeight;
        e.SeqPrefix = req.SeqPrefix ?? e.SeqPrefix;
        e.SeqNo = req.SeqNo ?? e.SeqNo;
        e.NoOfItems = req.NoOfItems ?? e.NoOfItems;
        e.Status = req.Status ?? e.Status;
        e.UpdateDt = DateOnly.FromDateTime(DateTime.UtcNow);
        e.UpdateTm = DateTime.UtcNow;
        e.UpdateBy = "api";
        await repo.UpdateHeaderAsync(e, ct);
        return true;
    }

    public async Task<bool> DeleteHeaderAsync(string fran, string brch, string whse, string packType, string packNo, CancellationToken ct)
    {
        var exists = await repo.GetHeaderByKeyAsync(fran, brch, whse, packType, packNo, ct);
        if (exists is null) return false;
        await repo.DeleteHeaderAsync(fran, brch, whse, packType, packNo, ct);
        return true;
    }

    // Lines
    public async Task<IReadOnlyList<PackingDetailDto>> GetAllLinesAsync(CancellationToken ct)
        => (await repo.GetAllLinesAsync(ct)).Select(ToDto).ToList();

    public async Task<PackingDetailDto?> GetLineByKeyAsync(string fran, string brch, string whse, string packType, string packNo, decimal packSrl, CancellationToken ct)
    {
        var e = await repo.GetLineByKeyAsync(fran, brch, whse, packType, packNo, packSrl, ct);
        return e is null ? null : ToDto(e);
    }

    public async Task<PackingDetailDto> CreateLineAsync(CreatePackingDetailRequest req, CancellationToken ct)
    {
        var e = new PackingDetail
        {
            Fran = req.Fran,
            Branch = req.Branch,
            Warehouse = req.Warehouse,
            PackType = req.PackType,
            PackNo = req.PackNo,
            PackSrl = req.PackSrl,
            Customer = req.Customer,
            CrtnType = req.CrtnType,
            Crtn = req.Crtn,
            MsCrtn = req.MsCrtn,
            CrtnSrl = req.CrtnSrl,
            Make = req.Make,
            Part = req.Part,
            Qty = req.Qty,
            UnitRate = req.UnitRate,
            NetValue = req.NetValue,
            PickType = req.PickType,
            PickNo = req.PickNo,
            PickSrl = req.PickSrl,
            CordType = req.CordType,
            CordNo = req.CordNo,
            CordSrl = req.CordSrl,
            LotNo = req.LotNo,
            PdCoo = req.PdCoo,
            PdHsCode = req.PdHsCode,
            NetWeight = req.NetWeight,
            GrossWeight = req.GrossWeight,
            UnitNetWeight = req.UnitNetWeight,
            UnitGrossWeight = req.UnitGrossWeight,
            GrossValue = req.GrossValue,
            PdStoreId = req.PdStoreId,
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

    public async Task<bool> UpdateLineAsync(string fran, string brch, string whse, string packType, string packNo, decimal packSrl, UpdatePackingDetailRequest req, CancellationToken ct)
    {
        var e = await repo.GetLineByKeyAsync(fran, brch, whse, packType, packNo, packSrl, ct);
        if (e is null) return false;
        e.Customer = req.Customer ?? e.Customer;
        e.CrtnType = req.CrtnType ?? e.CrtnType;
        e.Crtn = req.Crtn ?? e.Crtn;
        e.MsCrtn = req.MsCrtn ?? e.MsCrtn;
        e.CrtnSrl = req.CrtnSrl ?? e.CrtnSrl;
        e.Make = req.Make ?? e.Make;
        e.Part = req.Part ?? e.Part;
        e.Qty = req.Qty ?? e.Qty;
        e.UnitRate = req.UnitRate ?? e.UnitRate;
        e.NetValue = req.NetValue ?? e.NetValue;
        e.PickType = req.PickType ?? e.PickType;
        e.PickNo = req.PickNo ?? e.PickNo;
        e.PickSrl = req.PickSrl ?? e.PickSrl;
        e.CordType = req.CordType ?? e.CordType;
        e.CordNo = req.CordNo ?? e.CordNo;
        e.CordSrl = req.CordSrl ?? e.CordSrl;
        e.LotNo = req.LotNo ?? e.LotNo;
        e.PdCoo = req.PdCoo ?? e.PdCoo;
        e.PdHsCode = req.PdHsCode ?? e.PdHsCode;
        e.NetWeight = req.NetWeight ?? e.NetWeight;
        e.GrossWeight = req.GrossWeight ?? e.GrossWeight;
        e.UnitNetWeight = req.UnitNetWeight ?? e.UnitNetWeight;
        e.UnitGrossWeight = req.UnitGrossWeight ?? e.UnitGrossWeight;
        e.GrossValue = req.GrossValue ?? e.GrossValue;
        e.PdStoreId = req.PdStoreId ?? e.PdStoreId;
        e.Status = req.Status ?? e.Status;
        e.UpdateDt = DateOnly.FromDateTime(DateTime.UtcNow);
        e.UpdateTm = DateTime.UtcNow;
        e.UpdateBy = "api";
        await repo.UpdateLineAsync(e, ct);
        return true;
    }

    public async Task<bool> DeleteLineAsync(string fran, string brch, string whse, string packType, string packNo, decimal packSrl, CancellationToken ct)
    {
        var exists = await repo.GetLineByKeyAsync(fran, brch, whse, packType, packNo, packSrl, ct);
        if (exists is null) return false;
        await repo.DeleteLineAsync(fran, brch, whse, packType, packNo, packSrl, ct);
        return true;
    }

    private static PackingHeaderDto ToDto(PackingHeader x) => new()
    {
        Fran = x.Fran,
        Branch = x.Branch,
        Warehouse = x.Warehouse,
        PackType = x.PackType,
        PackNo = x.PackNo,
        PackDate = x.PackDate.ToString("yyyy-MM-dd"),
        Customer = x.Customer,
        Currency = x.Currency,
        CurrFactor = x.CurrFactor,
        DespFactor = x.DespFactor,
        NoOfCrtn = x.NoOfCrtn,
        GrossValue = x.GrossValue,
        NetValue = x.NetValue,
        NetWeight = x.NetWeight,
        GrossWeight = x.GrossWeight,
        SeqPrefix = x.SeqPrefix,
        SeqNo = x.SeqNo,
        NoOfItems = x.NoOfItems,
        Status = x.Status,
    };

    private static PackingDetailDto ToDto(PackingDetail x) => new()
    {
        Fran = x.Fran,
        Branch = x.Branch,
        Warehouse = x.Warehouse,
        PackType = x.PackType,
        PackNo = x.PackNo,
        PackSrl = x.PackSrl,
        Customer = x.Customer,
        CrtnType = x.CrtnType,
        Crtn = x.Crtn,
        MsCrtn = x.MsCrtn,
        CrtnSrl = x.CrtnSrl,
        Make = x.Make,
        Part = x.Part,
        Qty = x.Qty,
        UnitRate = x.UnitRate,
        NetValue = x.NetValue,
        PickType = x.PickType,
        PickNo = x.PickNo,
        PickSrl = x.PickSrl,
        CordType = x.CordType,
        CordNo = x.CordNo,
        CordSrl = x.CordSrl,
        LotNo = x.LotNo,
        PdCoo = x.PdCoo,
        PdHsCode = x.PdHsCode,
        NetWeight = x.NetWeight,
        GrossWeight = x.GrossWeight,
        UnitNetWeight = x.UnitNetWeight,
        UnitGrossWeight = x.UnitGrossWeight,
        GrossValue = x.GrossValue,
        PdStoreId = x.PdStoreId,
        Status = x.Status,
    };
}
