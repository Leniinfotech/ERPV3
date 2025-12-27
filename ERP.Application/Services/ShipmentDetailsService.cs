using ERP.Application.Interfaces.Repositories;
using ERP.Application.Interfaces.Services;
using ERP.Contracts.Orders;
using ERP.Domain.Entities;

namespace ERP.Application.Services;

public sealed class ShipmentDetailsService(IShipmentDetailsRepository repo) : IShipmentDetailsService
{
    public async Task<IReadOnlyList<ShipmentDetailDto>> GetAllAsync(CancellationToken ct)
        => (await repo.GetAllAsync(ct)).Select(ToDto).ToList();

    public async Task<ShipmentDetailDto?> GetByKeyAsync(string fran, string brch, string whse, string type, string no, decimal srl, CancellationToken ct)
    {
        var e = await repo.GetByKeyAsync(fran, brch, whse, type, no, srl, ct);
        return e is null ? null : ToDto(e);
    }

    public async Task<ShipmentDetailDto> CreateAsync(CreateShipmentDetailRequest req, CancellationToken ct)
    {
        var e = new ShipmentDetail
        {
            Fran = req.Fran,
            Branch = req.Branch,
            WarehouseCode = req.WarehouseCode,
            ShipmentType = req.ShipmentType,
            ShipmentNumber = req.ShipmentNumber,
            ShipmentSerial = req.ShipmentSerial,
            ShipmentDate = DateOnly.Parse(req.ShipmentDate),
            Vendor = req.Vendor,
            Make = req.Make,
            Part = req.Part,
            OrdPart = req.OrdPart,
            Qty = req.Qty,
            OrdQty = req.OrdQty,
            UnitPrice = req.UnitPrice,
            Discount = req.Discount,
            VatPercentage = req.VatPercentage,
            VatValue = req.VatValue,
            DiscountValue = req.DiscountValue,
            TotalValue = req.TotalValue,
            CaseNo = req.CaseNo,
            ContainerNo = req.ContainerNo,
            PoType = req.PoType,
            PoNo = req.PoNo,
            PoSrl = req.PoSrl,
            CreateDt = DateOnly.FromDateTime(DateTime.UtcNow),
            CreateTm = DateTime.UtcNow,
            CreateBy = "api",
            CreateRemarks = string.Empty,
            UpdateDt = DateOnly.FromDateTime(DateTime.UtcNow),
            UpdateTm = DateTime.UtcNow,
            UpdateBy = "api",
            UpdateRemarks = string.Empty,
        };
        await repo.CreateAsync(e, ct);
        return ToDto(e);
    }

    public async Task<bool> UpdateAsync(string fran, string brch, string whse, string type, string no, decimal srl, UpdateShipmentDetailRequest req, CancellationToken ct)
    {
        var e = await repo.GetByKeyAsync(fran, brch, whse, type, no, srl, ct);
        if (e is null) return false;
        e.ShipmentDate = req.ShipmentDate is null ? e.ShipmentDate : DateOnly.Parse(req.ShipmentDate);
        e.Vendor = req.Vendor ?? e.Vendor;
        e.Make = req.Make ?? e.Make;
        e.Part = req.Part ?? e.Part;
        e.OrdPart = req.OrdPart ?? e.OrdPart;
        e.Qty = req.Qty ?? e.Qty;
        e.OrdQty = req.OrdQty ?? e.OrdQty;
        e.UnitPrice = req.UnitPrice ?? e.UnitPrice;
        e.Discount = req.Discount ?? e.Discount;
        e.VatPercentage = req.VatPercentage ?? e.VatPercentage;
        e.VatValue = req.VatValue ?? e.VatValue;
        e.DiscountValue = req.DiscountValue ?? e.DiscountValue;
        e.TotalValue = req.TotalValue ?? e.TotalValue;
        e.CaseNo = req.CaseNo ?? e.CaseNo;
        e.ContainerNo = req.ContainerNo ?? e.ContainerNo;
        e.PoType = req.PoType ?? e.PoType;
        e.PoNo = req.PoNo ?? e.PoNo;
        e.PoSrl = req.PoSrl ?? e.PoSrl;
        e.UpdateDt = DateOnly.FromDateTime(DateTime.UtcNow);
        e.UpdateTm = DateTime.UtcNow;
        e.UpdateBy = "api";
        await repo.UpdateAsync(e, ct);
        return true;
    }

    public async Task<bool> DeleteAsync(string fran, string brch, string whse, string type, string no, decimal srl, CancellationToken ct)
    {
        var exists = await repo.GetByKeyAsync(fran, brch, whse, type, no, srl, ct);
        if (exists is null) return false;
        await repo.DeleteAsync(fran, brch, whse, type, no, srl, ct);
        return true;
    }

    private static ShipmentDetailDto ToDto(ShipmentDetail x) => new()
    {
        Fran = x.Fran,
        Branch = x.Branch,
        WarehouseCode = x.WarehouseCode,
        ShipmentType = x.ShipmentType,
        ShipmentNumber = x.ShipmentNumber,
        ShipmentSerial = x.ShipmentSerial,
        ShipmentDate = x.ShipmentDate.ToString("yyyy-MM-dd"),
        Vendor = x.Vendor,
        Make = x.Make,
        Part = x.Part,
        OrdPart = x.OrdPart,
        Qty = x.Qty,
        OrdQty = x.OrdQty,
        UnitPrice = x.UnitPrice,
        Discount = x.Discount,
        VatPercentage = x.VatPercentage,
        VatValue = x.VatValue,
        DiscountValue = x.DiscountValue,
        TotalValue = x.TotalValue,
        CaseNo = x.CaseNo,
        ContainerNo = x.ContainerNo,
        PoType = x.PoType,
        PoNo = x.PoNo,
        PoSrl = x.PoSrl,
    };
}
