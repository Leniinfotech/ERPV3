namespace ERP.Contracts.Finance;

// Read-only DTOs for Chart of Accounts
public record ChartOfAccountsDto(
    string Fran,
    string AccountType,
    string AccountCode,
    string AccountName,
    decimal AccountBalance,
    string Remarks,
    DateOnly CreateDt,
    DateTime CreateTm,
    string CreateBy
);
