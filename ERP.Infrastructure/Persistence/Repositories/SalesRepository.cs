using ERP.Application.Interfaces.Repositories;
using ERP.Contracts.Orders;
using ERP.Domain.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace ERP.Infrastructure.Persistence.Repositories;

public sealed class SalesRepository : ISalesRepository
{

    // Added: Added method for receivable and payable
    // Added by: Vaishnavi
    // Added on: 15-12-2025


    private readonly ErpDbContext _db;

    public SalesRepository(ErpDbContext db)
    {
        _db = db;
    }

    public async Task<IReadOnlyList<SaleReceivablePayableDto>>
        GetSaleReceivablePayableAsync(string fran, string mode, CancellationToken ct)
    {
        var result = new List<SaleReceivablePayableDto>();

        await using var conn = _db.Database.GetDbConnection();
        if (conn.State != System.Data.ConnectionState.Open)
            await conn.OpenAsync(ct);

        await using var cmd = conn.CreateCommand();
        cmd.CommandText = "SP_SALEHDR";
        cmd.CommandType = System.Data.CommandType.StoredProcedure;

        cmd.Parameters.Add(new SqlParameter("@FRAN", fran));
        cmd.Parameters.Add(new SqlParameter("@Mode", mode));

        await using var reader = await cmd.ExecuteReaderAsync(ct);

        while (await reader.ReadAsync(ct))
        {
            result.Add(new SaleReceivablePayableDto
            {
                Customer = reader["CUSTOMER"].ToString()!,
                InvoiceNo = reader["INVOICENO"].ToString()!,
                InvoiceDate = Convert.ToDateTime(reader["INVOICEDATE"]),
                DueDate = Convert.ToDateTime(reader["DUEDATE"]),
                TotalValue = Convert.ToDecimal(reader["TOTALVALUE"]),
                Paid = Convert.ToDecimal(reader["PAID"]),
                Pending = Convert.ToDecimal(reader["PENDING"]),
                Status = reader["STATUS"].ToString()!
            });
        }

        return result;
    }

    // Commented by: Vaishnavi
    // Commented on: 15-12-2025

    //public async Task<IReadOnlyList<SaleHeader>> GetAllHeadersAsync(CancellationToken ct)
    //    => await _db.SaleHeaders.AsNoTracking().OrderBy(x => x.Fran).ThenBy(x => x.Branch).ThenBy(x => x.Warehouse).ThenBy(x => x.SaleType).ThenBy(x => x.SaleNo).ToListAsync(ct);

    //public async Task<SaleHeader?> GetHeaderByKeyAsync(string fran, string brch, string whse, string saleType, string saleNo, CancellationToken ct)
    //    => await _db.SaleHeaders.AsNoTracking().FirstOrDefaultAsync(x => x.Fran == fran && x.Branch == brch && x.Warehouse == whse && x.SaleType == saleType && x.SaleNo == saleNo, ct);

    //public async Task CreateHeaderAsync(SaleHeader entity, CancellationToken ct)
    //{
    //    _db.SaleHeaders.Add(entity);
    //    await _db.SaveChangesAsync(ct);
    //}

    //public async Task UpdateHeaderAsync(SaleHeader entity, CancellationToken ct)
    //{
    //    _db.SaleHeaders.Update(entity);
    //    await _db.SaveChangesAsync(ct);
    //}

    //public async Task DeleteHeaderAsync(string fran, string brch, string whse, string saleType, string saleNo, CancellationToken ct)
    //{
    //    var tracked = await _db.SaleHeaders.FirstOrDefaultAsync(x => x.Fran == fran && x.Branch == brch && x.Warehouse == whse && x.SaleType == saleType && x.SaleNo == saleNo, ct);
    //    if (tracked is null) return;
    //    _db.SaleHeaders.Remove(tracked);
    //    await _db.SaveChangesAsync(ct);
    //}

    //public async Task<IReadOnlyList<SaleDetail>> GetAllLinesAsync(CancellationToken ct)
    //    => await _db.SaleDetails.AsNoTracking().OrderBy(x => x.Fran).ThenBy(x => x.Branch).ThenBy(x => x.Warehouse).ThenBy(x => x.SaleType).ThenBy(x => x.SaleNo).ThenBy(x => x.SalesRl).ToListAsync(ct);

    //public async Task<SaleDetail?> GetLineByKeyAsync(string fran, string brch, string whse, string saleType, string saleNo, string salesRl, CancellationToken ct)
    //    => await _db.SaleDetails.AsNoTracking().FirstOrDefaultAsync(x => x.Fran == fran && x.Branch == brch && x.Warehouse == whse && x.SaleType == saleType && x.SaleNo == saleNo && x.SalesRl == salesRl, ct);

    //public async Task CreateLineAsync(SaleDetail entity, CancellationToken ct)
    //{
    //    _db.SaleDetails.Add(entity);
    //    await _db.SaveChangesAsync(ct);
    //}

    //public async Task UpdateLineAsync(SaleDetail entity, CancellationToken ct)
    //{
    //    _db.SaleDetails.Update(entity);
    //    await _db.SaveChangesAsync(ct);
    //}

    //public async Task DeleteLineAsync(string fran, string brch, string whse, string saleType, string saleNo, string salesRl, CancellationToken ct)
    //{
    //    var tracked = await _db.SaleDetails.FirstOrDefaultAsync(x => x.Fran == fran && x.Branch == brch && x.Warehouse == whse && x.SaleType == saleType && x.SaleNo == saleNo && x.SalesRl == salesRl, ct);
    //    if (tracked is null) return;
    //    _db.SaleDetails.Remove(tracked);
    //    await _db.SaveChangesAsync(ct);
    //}
}
