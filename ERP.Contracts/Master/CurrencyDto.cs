namespace ERP.Contracts.Master;

public sealed class CurrencyDto
{
    public string CurrencyCode { get; set; } = string.Empty;
    public string BaseCurrency { get; set; } = string.Empty;
    public decimal Factor1 { get; set; }
    public decimal Factor2 { get; set; }
    public decimal DecimalPlace { get; set; }
}
