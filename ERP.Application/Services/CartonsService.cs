using ERP.Application.Interfaces.Repositories;
using ERP.Application.Interfaces.Services;
using ERP.Contracts.Inventory;
using ERP.Domain.Entities;

namespace ERP.Application.Services;

public sealed class CartonsService(ICartonsRepository repo) : ICartonsService
{
    // Headers (CRTN)
    public async Task<IReadOnlyList<CartonDto>> GetAllAsync(CancellationToken ct)
        => (await repo.GetAllAsync(ct)).Select(ToDto).ToList();

    public async Task<CartonDto?> GetByKeyAsync(string fran, string crtnType, string crtnCatg, CancellationToken ct)
    {
        var e = await repo.GetByKeyAsync(fran, crtnType, crtnCatg, ct);
        return e is null ? null : ToDto(e);
    }

    public async Task<CartonDto> CreateAsync(CreateCartonRequest req, CancellationToken ct)
    {
        var e = new Carton
        {
            Fran = req.Fran,
            CrtnType = req.CrtnType,
            CrtnCatg = req.CrtnCatg,
            CrtnDesc = req.CrtnDesc,
            Length = req.Length,
            Width = req.Width,
            Height = req.Height,
            Volume = req.Volume,
            MinWeight = req.MinWeight,
            MaxWeight = req.MaxWeight,
            CreateDt = DateOnly.FromDateTime(DateTime.UtcNow),
            CreateTm = DateTime.UtcNow,
            CreateBy = "api",
            CreateRemarks = string.Empty,
            UpdateDt = DateOnly.FromDateTime(DateTime.UtcNow),
            UpdateTm = DateTime.UtcNow,
            UpdateBy = "api",
            UpdateMarks = string.Empty,
        };
        await repo.CreateAsync(e, ct);
        return ToDto(e);
    }

    public async Task<bool> UpdateAsync(string fran, string crtnType, string crtnCatg, UpdateCartonRequest req, CancellationToken ct)
    {
        var e = await repo.GetByKeyAsync(fran, crtnType, crtnCatg, ct);
        if (e is null) return false;
        e.CrtnDesc = req.CrtnDesc ?? e.CrtnDesc;
        e.Length = req.Length ?? e.Length;
        e.Width = req.Width ?? e.Width;
        e.Height = req.Height ?? e.Height;
        e.Volume = req.Volume ?? e.Volume;
        e.MinWeight = req.MinWeight ?? e.MinWeight;
        e.MaxWeight = req.MaxWeight ?? e.MaxWeight;
        e.UpdateDt = DateOnly.FromDateTime(DateTime.UtcNow);
        e.UpdateTm = DateTime.UtcNow;
        e.UpdateBy = "api";
        await repo.UpdateAsync(e, ct);
        return true;
    }

    public async Task<bool> DeleteAsync(string fran, string crtnType, string crtnCatg, CancellationToken ct)
    {
        var exists = await repo.GetByKeyAsync(fran, crtnType, crtnCatg, ct);
        if (exists is null) return false;
        await repo.DeleteAsync(fran, crtnType, crtnCatg, ct);
        return true;
    }

    // Lines (CRTNDET)
    public async Task<IReadOnlyList<CartonDetailDto>> GetAllLinesAsync(CancellationToken ct)
        => (await repo.GetAllLinesAsync(ct)).Select(ToDto).ToList();

    public async Task<CartonDetailDto?> GetLineByKeyAsync(string cdf, string cdb, string cdw, string cdcrtn, string cdtype, decimal cdsrl, CancellationToken ct)
    {
        var e = await repo.GetLineByKeyAsync(cdf, cdb, cdw, cdcrtn, cdtype, cdsrl, ct);
        return e is null ? null : ToDto(e);
    }

    public async Task<CartonDetailDto> CreateLineAsync(CreateCartonDetailRequest req, CancellationToken ct)
    {
        var e = new CartonDetail
        {
            CDFRAN = req.CDFRAN,
            CDBRCH = req.CDBRCH,
            CDWHSE = req.CDWHSE,
            CDCRTN = req.CDCRTN,
            CDCRTNTYPE = req.CDCRTNTYPE,
            CDCRTNSRL = req.CDCRTNSRL,
            CDPART = req.CDPART,
            CDMAKE = req.CDMAKE,
            CDQTY = req.CDQTY,
            CDCKDQTY = req.CDCKDQTY,
            CDUNCKDQTY = req.CDUNCKDQTY,
            CDPICKTYPE = req.CDPICKTYPE,
            CDPICKNO = req.CDPICKNO,
            CDPICKSRL = req.CDPICKSRL,
            CDREFTYPE = req.CDREFTYPE,
            CDREFNO = req.CDREFNO,
            CDREFSRL = req.CDREFSRL,
            CDLOTNO = req.CDLOTNO,
            CDSTATUS = req.CDSTATUS,
            CDCUST = req.CDCUST,
            CDPKGCODE = req.CDPKGCODE,
            CDCOO = req.CDCOO,
            CDHSCODE = req.CDHSCODE,
            CDNETWEIGHT = req.CDNETWEIGHT,
            CDGROSSWEIGHT = req.CDGROSSWEIGHT,
            CDSUGGCOO = req.CDSUGGCOO,
            CDSUGGHSCODE = req.CDSUGGHSCODE,
            CDUNITNETWEIGHT = req.CDUNITNETWEIGHT,
            CDUNITGROSSWEIGHT = req.CDUNITGROSSWEIGHT,
            CDGROSSWEIGHT_ADJUSTED = req.CDGROSSWEIGHT_ADJUSTED,
            CDREMARKS = req.CDREMARKS,
            CDCREATEDT = DateTime.UtcNow,
            CDCREATETM = DateTime.UtcNow,
            CDCREATEBY = "api",
            CDCREATEREMARKS = string.Empty,
            CDUPDATEDT = DateTime.UtcNow,
            CDUPDATETM = DateTime.UtcNow,
            CDUPDATEBY = "api",
            CDUPDATEREMARKS = string.Empty,
        };
        await repo.CreateLineAsync(e, ct);
        return ToDto(e);
    }

    public async Task<bool> UpdateLineAsync(string cdf, string cdb, string cdw, string cdcrtn, string cdtype, decimal cdsrl, UpdateCartonDetailRequest req, CancellationToken ct)
    {
        var e = await repo.GetLineByKeyAsync(cdf, cdb, cdw, cdcrtn, cdtype, cdsrl, ct);
        if (e is null) return false;
        e.CDPART = req.CDPART ?? e.CDPART;
        e.CDMAKE = req.CDMAKE ?? e.CDMAKE;
        e.CDQTY = req.CDQTY ?? e.CDQTY;
        e.CDCKDQTY = req.CDCKDQTY ?? e.CDCKDQTY;
        e.CDUNCKDQTY = req.CDUNCKDQTY ?? e.CDUNCKDQTY;
        e.CDPICKTYPE = req.CDPICKTYPE ?? e.CDPICKTYPE;
        e.CDPICKNO = req.CDPICKNO ?? e.CDPICKNO;
        e.CDPICKSRL = req.CDPICKSRL ?? e.CDPICKSRL;
        e.CDREFTYPE = req.CDREFTYPE ?? e.CDREFTYPE;
        e.CDREFNO = req.CDREFNO ?? e.CDREFNO;
        e.CDREFSRL = req.CDREFSRL ?? e.CDREFSRL;
        e.CDLOTNO = req.CDLOTNO ?? e.CDLOTNO;
        e.CDSTATUS = req.CDSTATUS ?? e.CDSTATUS;
        e.CDCUST = req.CDCUST ?? e.CDCUST;
        e.CDPKGCODE = req.CDPKGCODE ?? e.CDPKGCODE;
        e.CDCOO = req.CDCOO ?? e.CDCOO;
        e.CDHSCODE = req.CDHSCODE ?? e.CDHSCODE;
        e.CDNETWEIGHT = req.CDNETWEIGHT ?? e.CDNETWEIGHT;
        e.CDGROSSWEIGHT = req.CDGROSSWEIGHT ?? e.CDGROSSWEIGHT;
        e.CDSUGGCOO = req.CDSUGGCOO ?? e.CDSUGGCOO;
        e.CDSUGGHSCODE = req.CDSUGGHSCODE ?? e.CDSUGGHSCODE;
        e.CDUNITNETWEIGHT = req.CDUNITNETWEIGHT ?? e.CDUNITNETWEIGHT;
        e.CDUNITGROSSWEIGHT = req.CDUNITGROSSWEIGHT ?? e.CDUNITGROSSWEIGHT;
        e.CDGROSSWEIGHT_ADJUSTED = req.CDGROSSWEIGHT_ADJUSTED ?? e.CDGROSSWEIGHT_ADJUSTED;
        e.CDREMARKS = req.CDREMARKS ?? e.CDREMARKS;
        e.CDUPDATEDT = DateTime.UtcNow;
        e.CDUPDATETM = DateTime.UtcNow;
        e.CDUPDATEBY = "api";
        await repo.UpdateLineAsync(e, ct);
        return true;
    }

    public async Task<bool> DeleteLineAsync(string cdf, string cdb, string cdw, string cdcrtn, string cdtype, decimal cdsrl, CancellationToken ct)
    {
        var exists = await repo.GetLineByKeyAsync(cdf, cdb, cdw, cdcrtn, cdtype, cdsrl, ct);
        if (exists is null) return false;
        await repo.DeleteLineAsync(cdf, cdb, cdw, cdcrtn, cdtype, cdsrl, ct);
        return true;
    }

    private static CartonDto ToDto(Carton x) => new()
    {
        Fran = x.Fran,
        CrtnType = x.CrtnType,
        CrtnCatg = x.CrtnCatg,
        Id = x.Id,
        CrtnDesc = x.CrtnDesc,
        Length = x.Length,
        Width = x.Width,
        Height = x.Height,
        Volume = x.Volume,
        MinWeight = x.MinWeight,
        MaxWeight = x.MaxWeight,
    };

    private static CartonDetailDto ToDto(CartonDetail x) => new()
    {
        CDFRAN = x.CDFRAN,
        CDBRCH = x.CDBRCH,
        CDWHSE = x.CDWHSE,
        CDCRTN = x.CDCRTN,
        CDCRTNTYPE = x.CDCRTNTYPE,
        CDCRTNSRL = x.CDCRTNSRL,
        CDPART = x.CDPART,
        CDMAKE = x.CDMAKE,
        CDQTY = x.CDQTY,
        CDCKDQTY = x.CDCKDQTY,
        CDUNCKDQTY = x.CDUNCKDQTY,
        CDPICKTYPE = x.CDPICKTYPE,
        CDPICKNO = x.CDPICKNO,
        CDPICKSRL = x.CDPICKSRL,
        CDREFTYPE = x.CDREFTYPE,
        CDREFNO = x.CDREFNO,
        CDREFSRL = x.CDREFSRL,
        CDLOTNO = x.CDLOTNO,
        CDSTATUS = x.CDSTATUS,
        CDCUST = x.CDCUST,
        CDPKGCODE = x.CDPKGCODE,
        CDCOO = x.CDCOO,
        CDHSCODE = x.CDHSCODE,
        CDNETWEIGHT = x.CDNETWEIGHT,
        CDGROSSWEIGHT = x.CDGROSSWEIGHT,
        CDSUGGCOO = x.CDSUGGCOO,
        CDSUGGHSCODE = x.CDSUGGHSCODE,
        CDUNITNETWEIGHT = x.CDUNITNETWEIGHT,
        CDUNITGROSSWEIGHT = x.CDUNITGROSSWEIGHT,
        CDGROSSWEIGHT_ADJUSTED = x.CDGROSSWEIGHT_ADJUSTED,
        CDREMARKS = x.CDREMARKS,
    };
}
