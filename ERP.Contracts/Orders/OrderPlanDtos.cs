namespace ERP.Contracts.Orders;

public record OrderPlanHeaderDto(
    string Fran,
    string Branch,
    string Warehouse,
    string PlanType,
    string PlanNo,
    DateTime PlanDate,
    string TranType,
    decimal SeqNo,
    decimal NoItems,
    decimal NetValue,
    string Status,
    DateOnly CreateDt,
    DateTime CreateTm,
    string CreateBy
);

public record CreateOrderPlanHeaderRequest(
    string Fran,
    string Branch,
    string Warehouse,
    string PlanType,
    string PlanNo,
    DateTime? PlanDate = null,
    string? TranType = null,
    decimal? SeqNo = null,
    decimal? NoItems = null,
    decimal? NetValue = null,
    string? Status = null
);

public record UpdateOrderPlanHeaderRequest(
    DateTime? PlanDate = null,
    string? TranType = null,
    decimal? SeqNo = null,
    decimal? NoItems = null,
    decimal? NetValue = null,
    string? Status = null
);

public record OrderPlanDetailDto(
    string Fran,
    string Branch,
    string Warehouse,
    string PlanType,
    decimal PlanNo,
    decimal PlanSrl,
    DateTime PlanDate,
    string Vendor,
    string Make,
    string Part,
    decimal Qty,
    decimal UnitPrice,
    decimal NetValue,
    string Currency,
    string Remarks,
    DateOnly CreateDt,
    DateTime CreateTm,
    string CreateBy
);

public record CreateOrderPlanDetailRequest(
    string Fran,
    string Branch,
    string Warehouse,
    string PlanType,
    decimal PlanNo,
    decimal PlanSrl,
    DateTime? PlanDate = null,
    string? Vendor = null,
    string? Make = null,
    string? Part = null,
    decimal? Qty = null,
    decimal? UnitPrice = null,
    decimal? NetValue = null,
    string? Currency = null,
    string? Remarks = null
);

public record UpdateOrderPlanDetailRequest(
    DateTime? PlanDate = null,
    string? Vendor = null,
    string? Make = null,
    string? Part = null,
    decimal? Qty = null,
    decimal? UnitPrice = null,
    decimal? NetValue = null,
    string? Currency = null,
    string? Remarks = null
);

public record OrderPlanMasterDto(
    decimal Id,
    string Fran,
    string Type,
    string Name,
    string SelectSql,
    string FilterSql,
    string GroupBySql,
    string OrderBySql,
    DateOnly CreateDt,
    DateTime CreateTm,
    string CreateBy
);

public record CreateOrderPlanMasterRequest(
    string Fran,
    string Type,
    string Name,
    string? SelectSql = null,
    string? FilterSql = null,
    string? GroupBySql = null,
    string? OrderBySql = null
);

public record UpdateOrderPlanMasterRequest(
    string? SelectSql = null,
    string? FilterSql = null,
    string? GroupBySql = null,
    string? OrderBySql = null
);
