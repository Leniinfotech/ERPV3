using ERP.Application.Interfaces.Repositories;
using ERP.Contracts.Finance;
using ERP.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ERP.Infrastructure.Persistence.Repositories;

public sealed class ParamsRepository(ErpDbContext db) : IParamsRepository
{
    public async Task<Params?> GetByKeyAsync(string fran, string paramType, string paramValue, CancellationToken ct)
    {
        return await db.Params.AsNoTracking()
            .FirstOrDefaultAsync(x => x.Fran == fran && x.ParamType == paramType && x.ParamValue == paramValue, ct);
    }

    public async Task<IReadOnlyList<Params>> GetAllAsync(CancellationToken ct)
    {
        return await db.Params.AsNoTracking().OrderBy(x => x.Fran).ThenBy(x => x.ParamType).ThenBy(x => x.ParamValue).ToListAsync(ct);
    }

    // Added: Added method to loadparam
    // Added by: Vaishnavi
    // Added on: 12-12-2025
    public async Task<IReadOnlyList<LoadParam>> LoadByParamAsync(string fran, string paramType, CancellationToken ct)
    {
        var results = new List<LoadParam>();

        using var conn = db.Database.GetDbConnection();
        if (conn.State == System.Data.ConnectionState.Closed)
            await conn.OpenAsync(ct);

        using var cmd = conn.CreateCommand();
        cmd.CommandText = "SP_LOAD_PARAM";
        cmd.CommandType = System.Data.CommandType.StoredProcedure;

        var p1 = cmd.CreateParameter();
        p1.ParameterName = "@FRAN";
        p1.Value = fran;
        cmd.Parameters.Add(p1);

        var p2 = cmd.CreateParameter();
        p2.ParameterName = "@PARAMTYPE";
        p2.Value = paramType;
        cmd.Parameters.Add(p2);

        using var reader = await cmd.ExecuteReaderAsync(ct);
        while (await reader.ReadAsync(ct))
        {
            results.Add(new LoadParam
            {
                ParamValue = reader["PARAMVALUE"].ToString() ?? "",
                ParamDesc = reader["PARAMDESC"].ToString() ?? ""
            });
        }

        return results;
    }
}
