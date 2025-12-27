namespace ERP.Contracts.Finance;

// Read-only DTOs for Params
public record ParamsDto(
    decimal Id,
    string Fran,
    string ParamType,
    string ParamValue,
    string ParamValueStr1,
    decimal ParamValueNum1,
    string ParamDesc,
    string ParamCategory,
    string ParamRemarks,
    DateOnly CreateDt,
    DateTime CreateTm,
    string CreateBy
);

// Added: Added method to loadparam
// Added by: Vaishnavi
// Added on: 12-12-2025
public sealed class LoadParam
{
    public string ParamValue { get; set; } = "";
    public string ParamDesc { get; set; } = "";
}
