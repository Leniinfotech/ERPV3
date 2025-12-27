namespace ERP.Domain.Entities;

public sealed class LoadingAdviceDetail2
{
    // PK: FRAN, BRCH, WHSE, INVTYPE, INVNO, INVSRL
    public string Fran { get; set; } = null!;
    public string Branch { get; set; } = null!;
    public string Warehouse { get; set; } = null!;
    public string InvType { get; set; } = null!;
    public string InvNo { get; set; } = null!;
    public decimal InvSrl { get; set; }
    
    public DateOnly InvDate { get; set; }
    public string Customer { get; set; } = string.Empty;
    public string Part { get; set; } = string.Empty;
    public string Make { get; set; } = string.Empty;
    public decimal Qty { get; set; }
    public decimal UnitRate { get; set; }
    public decimal NetValue { get; set; }
    public decimal CurrencyFactor { get; set; }
    public decimal UnitGrossWeight { get; set; }
    public decimal UnitNetWeight { get; set; }
    public string LaType { get; set; } = string.Empty;
    public string LaNo { get; set; } = string.Empty;
    public decimal LaSrl { get; set; }
    public string PackNo { get; set; } = string.Empty;
    public decimal PickNo { get; set; }
    public string Crtn { get; set; } = string.Empty;
    public string Coo { get; set; } = string.Empty;
    public string HsCode { get; set; } = string.Empty;
    public decimal? Length { get; set; }
    public decimal Width { get; set; }
    public decimal Height { get; set; }
    public decimal Volume { get; set; }
    public decimal NetWeight { get; set; }
    public decimal GrossWeight { get; set; }
    public decimal KeyInGrossWeight { get; set; }
    public string Currency { get; set; } = string.Empty;
    public string StoreId { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    
    // Audit
    public DateOnly CreateDt { get; set; }
    public DateTime CreateTm { get; set; }
    public string CreateBy { get; set; } = string.Empty;
    public string CreateRemarks { get; set; } = string.Empty;
    public DateOnly UpdateDt { get; set; }
    public DateTime UpdateTm { get; set; }
    public string UpdateBy { get; set; } = string.Empty;
    public string UpdateRemarks { get; set; } = string.Empty;
}
