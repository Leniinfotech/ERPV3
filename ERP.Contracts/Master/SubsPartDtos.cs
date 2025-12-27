namespace ERP.Contracts.Master;

public record SubsPartDto(
    string Fran,
    string Make,
    string Part,
    string FinalPart,
    decimal GrpNo,
    decimal PsSubSeq,
    DateOnly CreateDt,
    DateTime CreateTm,
    string CreateBy
);

public record CreateSubsPartRequest(
    string Fran,
    string Make,
    string Part,
    string FinalPart,
    decimal GrpNo,
    decimal? PsSubSeq = null
);

public record UpdateSubsPartRequest(
    decimal? PsSubSeq = null
);
