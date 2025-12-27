namespace ERP.Contracts.Master;

public sealed record CreateCurrencyRequest(string CurrencyCode, string BaseCurrency, decimal Factor1, decimal Factor2, decimal DecimalPlace);
public sealed record UpdateCurrencyRequest(string? BaseCurrency, decimal? Factor1, decimal? Factor2, decimal? DecimalPlace);
