namespace ERP.Contracts.Orders;

public record LoadingAdviceHeaderDto(
    string Fran,
    string Branch,
    string Warehouse,
    string LaType,
    string LaNo,
    DateTime LaDate,
    string InvType,
    string InvNo,
    string Customer,
    decimal SeqNo,
    string Vessel,
    string PortDest,
    DateTime Etd,
    DateTime Eta,
    DateTime LoadDate,
    string Status,
    decimal NoOfCrtn,
    string Remarks,
    DateOnly CreateDt,
    DateTime CreateTm,
    string CreateBy
);

public record CreateLoadingAdviceHeaderRequest(
    string Fran,
    string Branch,
    string Warehouse,
    string LaType,
    string LaNo,
    DateTime? LaDate = null,
    string? InvType = null,
    string? InvNo = null,
    string? Customer = null,
    decimal? SeqNo = null,
    string? Vessel = null,
    string? PortDest = null,
    DateTime? Etd = null,
    DateTime? Eta = null,
    DateTime? LoadDate = null,
    string? Status = null,
    decimal? NoOfCrtn = null,
    string? Remarks = null
);

public record UpdateLoadingAdviceHeaderRequest(
    DateTime? LaDate = null,
    string? InvType = null,
    string? InvNo = null,
    string? Customer = null,
    decimal? SeqNo = null,
    string? Vessel = null,
    string? PortDest = null,
    DateTime? Etd = null,
    DateTime? Eta = null,
    DateTime? LoadDate = null,
    string? Status = null,
    decimal? NoOfCrtn = null,
    string? Remarks = null
);

public record LoadingAdviceDetailDto(
    string Fran,
    string Branch,
    string Warehouse,
    string LaType,
    string LaNo,
    string CrtnType,
    string Crtn,
    DateTime DocDate,
    string CntrNo,
    DateOnly CntrDate,
    string MsCrtn,
    string PackType,
    string PackNo,
    string Customer,
    string InvType,
    string InvNo,
    string SubInvNo,
    string Status,
    DateOnly CreateDt,
    DateTime CreateTm,
    string CreateBy
);

public record CreateLoadingAdviceDetailRequest(
    string Fran,
    string Branch,
    string Warehouse,
    string LaType,
    string LaNo,
    string CrtnType,
    string Crtn,
    DateTime? DocDate = null,
    string? CntrNo = null,
    DateOnly? CntrDate = null,
    string? MsCrtn = null,
    string? PackType = null,
    string? PackNo = null,
    string? Customer = null,
    string? InvType = null,
    string? InvNo = null,
    string? SubInvNo = null,
    string? Status = null
);

public record UpdateLoadingAdviceDetailRequest(
    DateTime? DocDate = null,
    string? CntrNo = null,
    DateOnly? CntrDate = null,
    string? MsCrtn = null,
    string? PackType = null,
    string? PackNo = null,
    string? Customer = null,
    string? InvType = null,
    string? InvNo = null,
    string? SubInvNo = null,
    string? Status = null
);

public record LoadingAdviceDetail2Dto(
    string Fran,
    string Branch,
    string Warehouse,
    string InvType,
    string InvNo,
    decimal InvSrl,
    DateOnly InvDate,
    string Customer,
    string Part,
    string Make,
    decimal Qty,
    decimal UnitRate,
    decimal NetValue,
    string Currency,
    string Status,
    DateOnly CreateDt,
    DateTime CreateTm,
    string CreateBy
);

public record CreateLoadingAdviceDetail2Request(
    string Fran,
    string Branch,
    string Warehouse,
    string InvType,
    string InvNo,
    decimal InvSrl,
    DateOnly? InvDate = null,
    string? Customer = null,
    string? Part = null,
    string? Make = null,
    decimal? Qty = null,
    decimal? UnitRate = null,
    decimal? NetValue = null,
    string? Currency = null,
    string? Status = null
);

public record UpdateLoadingAdviceDetail2Request(
    DateOnly? InvDate = null,
    string? Customer = null,
    string? Part = null,
    string? Make = null,
    decimal? Qty = null,
    decimal? UnitRate = null,
    decimal? NetValue = null,
    string? Currency = null,
    string? Status = null
);
