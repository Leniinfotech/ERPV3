namespace ERP.Contracts.Finance;

public sealed class JournalEntryHeaderDto
{
    public string Fran { get; set; } = null!;
    public string JournalType { get; set; } = null!;
    public decimal JournalEntryId { get; set; }
    public string JournalEntryDate { get; set; } = null!;
    public string? Description { get; set; }
    public string? Reference { get; set; }
}

public sealed class JournalEntryLineDto
{
    public string Fran { get; set; } = null!;
    public decimal JournalEntryId { get; set; }
    public decimal JournalEntryLineId { get; set; }
    public decimal AccountCode { get; set; }
    public decimal Debit { get; set; }
    public decimal Credit { get; set; }
    public string? Remarks { get; set; }
}

// Added: Added method to insert journal 
// Added by: Vaishnavi
// Added on: 15-12-2025

public sealed class InsertJournalEntryRequestDto
{
    public string Customer { get; set; } = null!;
    public string SaleNo { get; set; } = null!;
    public decimal BillAmount { get; set; }
    public string PaymentMethod { get; set; } = null!;
    public string? CardNumber { get; set; }
    public string? Remarks { get; set; }
}