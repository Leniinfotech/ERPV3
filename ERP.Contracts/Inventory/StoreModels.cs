namespace ERP.Contracts.Inventory;

public sealed record CreateStoreRequest(string Fran, string Branch, string WarehouseCode, string StoreCode, string Name);
public sealed record UpdateStoreRequest(string? Name);
