using ERP.Application.Interfaces.Repositories;
using ERP.Application.Interfaces.Services;
using ERP.Contracts.Master;
using ERP.Domain.Entities;

namespace ERP.Application.Services;

public sealed class CustomersService(ICustomersRepository repo) : ICustomersService
{
    public async Task<IReadOnlyList<CustomerDto>> GetAllAsync(CancellationToken ct)
    {
        var rows = await repo.GetAllAsync(ct);
        return rows.Select(ToDto).ToList();
    }

    public async Task<CustomerDto?> GetByCodeAsync(string customerCode, CancellationToken ct)
    {
        var x = await repo.GetByCodeAsync(customerCode, ct);
        return x is null ? null : ToDto(x);
    }

    public async Task<CustomerDto> CreateAsync(CreateCustomerRequest req, CancellationToken ct)
    {
        var now = DateTime.UtcNow;

        var entity = new Customer
        {
            CustomerCode = req.CustomerCode,
            Name = req.Name,
            NameAr = req.NameAr,
            Phone = req.Phone,
            Email = req.Email,
            Address = req.Address,
            VatNo = req.VatNo,

            // ✅ FIX (DateOnly + DateTime correctly assigned)
            CreateDt = DateOnly.FromDateTime(now),
            CreateTm = now,
            CreateBy = "api",

            UpdateDt = DateOnly.FromDateTime(now),
            UpdateTm = now,
            UpdateBy = "api",
        };

        await repo.CreateAsync(entity, ct);
        return ToDto(entity);
    }

    public async Task<bool> UpdateAsync(string customerCode, UpdateCustomerRequest req, CancellationToken ct)
    {
        var current = await repo.GetByCodeAsync(customerCode, ct);
        if (current is null) return false;

        var now = DateTime.UtcNow;

        // Non-destructive update
        current.Name = req.Name ?? current.Name;
        current.NameAr = req.NameAr ?? current.NameAr;
        current.Phone = req.Phone ?? current.Phone;
        current.Email = req.Email ?? current.Email;
        current.Address = req.Address ?? current.Address;
        current.VatNo = req.VatNo ?? current.VatNo;

        // ✅ FIX
        current.UpdateDt = DateOnly.FromDateTime(now);
        current.UpdateTm = now;
        current.UpdateBy = "api";

        await repo.UpdateAsync(current, ct);
        return true;
    }

    public async Task<bool> DeleteAsync(string customerCode, CancellationToken ct)
    {
        var current = await repo.GetByCodeAsync(customerCode, ct);
        if (current is null) return false;

        await repo.DeleteAsync(customerCode, ct);
        return true;
    }

    private static CustomerDto ToDto(Customer x) => new()
    {
        CustomerCode = x.CustomerCode,
        Id = x.Id,
        Name = x.Name,
        NameAr = x.NameAr,
        Phone = x.Phone,
        Email = x.Email,
        Address = x.Address,
        VatNo = x.VatNo
    };
}
