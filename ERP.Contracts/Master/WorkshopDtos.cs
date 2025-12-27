namespace ERP.Contracts.Master;

public sealed class WorkshopDto
{
    public string Fran { get; set; } = null!;
    public decimal WorkshopId { get; set; }
    public string Name { get; set; } = string.Empty;
}

public sealed class CreateWorkshopRequest
{
    public string Fran { get; set; } = null!;
    public decimal WorkshopId { get; set; }
    public string Name { get; set; } = string.Empty;
}

public sealed class UpdateWorkshopRequest
{
    public string? Name { get; set; }
}
