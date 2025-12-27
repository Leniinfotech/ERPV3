namespace ERP.Domain.Entities;

public sealed class CartonDetail
{
    // PK: { CDFRAN, CDBRCH, CDWHSE, CDCRTN, CDCRTNTYPE, CDCRTNSRL }
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

    // Audit
    public DateTime CDCREATEDT { get; set; }
    public DateTime CDCREATETM { get; set; }
    public string CDCREATEBY { get; set; } = string.Empty;
    public string CDCREATEREMARKS { get; set; } = string.Empty;
    public DateTime CDUPDATEDT { get; set; }
    public DateTime CDUPDATETM { get; set; }
    public string CDUPDATEBY { get; set; } = string.Empty;
    public string CDUPDATEREMARKS { get; set; } = string.Empty;
}
