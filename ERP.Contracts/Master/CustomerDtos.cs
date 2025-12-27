namespace ERP.Contracts.Master;

public sealed class CustomerDto
{
    public string CustomerCode { get; set; } = null!;
    public decimal Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string NameAr { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string VatNo { get; set; } = string.Empty;
}

public sealed class CreateCustomerRequest
{
    public string CustomerCode { get; set; } = null!;
    public string Name { get; set; } = string.Empty;
    public string NameAr { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string VatNo { get; set; } = string.Empty;
}

public sealed class UpdateCustomerRequest
{
    public string? Name { get; set; }
    public string? NameAr { get; set; }
    public string? Phone { get; set; }
    public string? Email { get; set; }
    public string? Address { get; set; }
    public string? VatNo { get; set; }
}
