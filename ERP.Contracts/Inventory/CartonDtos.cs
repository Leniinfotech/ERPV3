namespace ERP.Contracts.Inventory;

public sealed class CartonDto
{
    public string Fran { get; set; } = null!;
    public string CrtnType { get; set; } = null!;
    public string CrtnCatg { get; set; } = null!;
    public decimal Id { get; set; }
    public string CrtnDesc { get; set; } = string.Empty;
    public decimal Length { get; set; }
    public decimal Width { get; set; }
    public decimal Height { get; set; }
    public decimal Volume { get; set; }
    public decimal MinWeight { get; set; }
    public decimal MaxWeight { get; set; }
}

public sealed class CreateCartonRequest
{
    public string Fran { get; set; } = null!;
    public string CrtnType { get; set; } = null!;
    public string CrtnCatg { get; set; } = null!;
    public string CrtnDesc { get; set; } = string.Empty;
    public decimal Length { get; set; }
    public decimal Width { get; set; }
    public decimal Height { get; set; }
    public decimal Volume { get; set; }
    public decimal MinWeight { get; set; }
    public decimal MaxWeight { get; set; }
}

public sealed class UpdateCartonRequest
{
    public string? CrtnDesc { get; set; }
    public decimal? Length { get; set; }
    public decimal? Width { get; set; }
    public decimal? Height { get; set; }
    public decimal? Volume { get; set; }
    public decimal? MinWeight { get; set; }
    public decimal? MaxWeight { get; set; }
}

public sealed class CartonDetailDto
{
    public string CDFRAN { get; set; } = null!;
    public string CDBRCH { get; set; } = null!;
    public string CDWHSE { get; set; } = null!;
    public string CDCRTN { get; set; } = null!;
    public string CDCRTNTYPE { get; set; } = null!;
    public decimal CDCRTNSRL { get; set; }
    public string CDPART { get; set; } = string.Empty;
    public string CDMAKE { get; set; } = string.Empty;
    public decimal CDQTY { get; set; }
    public decimal CDCKDQTY { get; set; }
    public decimal CDUNCKDQTY { get; set; }
    public string CDPICKTYPE { get; set; } = string.Empty;
    public decimal CDPICKNO { get; set; }
    public decimal CDPICKSRL { get; set; }
    public string CDREFTYPE { get; set; } = string.Empty;
    public string CDREFNO { get; set; } = string.Empty;
    public decimal CDREFSRL { get; set; }
    public string CDLOTNO { get; set; } = string.Empty;
    public string CDSTATUS { get; set; } = string.Empty;
    public string CDCUST { get; set; } = string.Empty;
    public string CDPKGCODE { get; set; } = string.Empty;
    public string CDCOO { get; set; } = string.Empty;
    public string CDHSCODE { get; set; } = string.Empty;
    public decimal CDNETWEIGHT { get; set; }
    public decimal CDGROSSWEIGHT { get; set; }
    public string CDSUGGCOO { get; set; } = string.Empty;
    public string CDSUGGHSCODE { get; set; } = string.Empty;
    public decimal CDUNITNETWEIGHT { get; set; }
    public decimal CDUNITGROSSWEIGHT { get; set; }
    public decimal CDGROSSWEIGHT_ADJUSTED { get; set; }
    public string CDREMARKS { get; set; } = string.Empty;
}

public sealed class CreateCartonDetailRequest
{
    public string CDFRAN { get; set; } = null!;
    public string CDBRCH { get; set; } = null!;
    public string CDWHSE { get; set; } = null!;
    public string CDCRTN { get; set; } = null!;
    public string CDCRTNTYPE { get; set; } = null!;
    public decimal CDCRTNSRL { get; set; }
    public string CDPART { get; set; } = string.Empty;
    public string CDMAKE { get; set; } = string.Empty;
    public decimal CDQTY { get; set; }
    public decimal CDCKDQTY { get; set; }
    public decimal CDUNCKDQTY { get; set; }
    public string CDPICKTYPE { get; set; } = string.Empty;
    public decimal CDPICKNO { get; set; }
    public decimal CDPICKSRL { get; set; }
    public string CDREFTYPE { get; set; } = string.Empty;
    public string CDREFNO { get; set; } = string.Empty;
    public decimal CDREFSRL { get; set; }
    public string CDLOTNO { get; set; } = string.Empty;
    public string CDSTATUS { get; set; } = string.Empty;
    public string CDCUST { get; set; } = string.Empty;
    public string CDPKGCODE { get; set; } = string.Empty;
    public string CDCOO { get; set; } = string.Empty;
    public string CDHSCODE { get; set; } = string.Empty;
    public decimal CDNETWEIGHT { get; set; }
    public decimal CDGROSSWEIGHT { get; set; }
    public string CDSUGGCOO { get; set; } = string.Empty;
    public string CDSUGGHSCODE { get; set; } = string.Empty;
    public decimal CDUNITNETWEIGHT { get; set; }
    public decimal CDUNITGROSSWEIGHT { get; set; }
    public decimal CDGROSSWEIGHT_ADJUSTED { get; set; }
    public string CDREMARKS { get; set; } = string.Empty;
}

public sealed class UpdateCartonDetailRequest
{
    public string? CDPART { get; set; }
    public string? CDMAKE { get; set; }
    public decimal? CDQTY { get; set; }
    public decimal? CDCKDQTY { get; set; }
    public decimal? CDUNCKDQTY { get; set; }
    public string? CDPICKTYPE { get; set; }
    public decimal? CDPICKNO { get; set; }
    public decimal? CDPICKSRL { get; set; }
    public string? CDREFTYPE { get; set; }
    public string? CDREFNO { get; set; }
    public decimal? CDREFSRL { get; set; }
    public string? CDLOTNO { get; set; }
    public string? CDSTATUS { get; set; }
    public string? CDCUST { get; set; }
    public string? CDPKGCODE { get; set; }
    public string? CDCOO { get; set; }
    public string? CDHSCODE { get; set; }
    public decimal? CDNETWEIGHT { get; set; }
    public decimal? CDGROSSWEIGHT { get; set; }
    public string? CDSUGGCOO { get; set; }
    public string? CDSUGGHSCODE { get; set; }
    public decimal? CDUNITNETWEIGHT { get; set; }
    public decimal? CDUNITGROSSWEIGHT { get; set; }
    public decimal? CDGROSSWEIGHT_ADJUSTED { get; set; }
    public string? CDREMARKS { get; set; }
}
