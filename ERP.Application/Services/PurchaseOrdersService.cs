using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ERP.Application.Abstractions.Logging;
using ERP.Application.Interfaces.Repositories;
using ERP.Application.Interfaces.Services;
using ERP.Contracts.Orders;
using ERP.Domain.Entities;

namespace ERP.Application.Services
{
    /// <summary>Application service for Purchase Orders.</summary>
    public sealed class PurchaseOrdersService : IPurchaseOrdersService
    {
        private readonly IPurchaseOrdersRepository _repo;
        private readonly IAppLogger<PurchaseOrdersService> _log;

        public PurchaseOrdersService(IPurchaseOrdersRepository repo, IAppLogger<PurchaseOrdersService> log)
        {
            _repo = repo;
            _log = log;
        }

        public async Task<IReadOnlyList<PurchaseOrderDto>> GetAllAsync(CancellationToken ct)
        {
            var list = await _repo.GetAllAsync(ct);
            return list.Select(ToDtoHeaderOnly).ToList();
        }

        public async Task<PurchaseOrderDto?> GetByKeyAsync(string fran, string branch, string warehouseCode, string poType, string poNumber, CancellationToken ct)
        {
            var entity = await _repo.GetByKeyAsync(fran, branch, warehouseCode, poType, poNumber, ct);
            return entity is null ? null : ToDto(entity);
        }

        public async Task<PurchaseOrderDto> CreateAsync(PurchaseOrderDto dto, CancellationToken ct)
        {
            var header = ToEntityHeader(dto);
            var lines = dto.Lines.Select(ToEntityLine).ToList();

            // Safe defaults for NOT NULL columns
            header.SupplierRefNo = (header.SupplierRefNo ?? string.Empty).PadRight(0); // ensure not null
            header.Currency = header.Currency ?? "USD";
            header.NoOfItems = header.NoOfItems;
            header.Discount = header.Discount;
            header.TotalValue = header.TotalValue;

            // Audit defaults
            var today = DateOnly.FromDateTime(DateTime.UtcNow);
            var now = DateTime.UtcNow;
            header.CreateDt = today;
            header.CreateTm = now;
            header.CreateBy = string.Empty;
            header.CreateRemarks = string.Empty;
            header.UpdateDt = today;
            header.UpdateTm = now;
            header.UpdateBy = string.Empty;
            header.UpdateRemarks = string.Empty;

            // Lines defaults incl. audit
            foreach (var l in lines)
            {
                l.PlanType = l.PlanType ?? string.Empty;
                l.PlanNo = l.PlanNo ?? string.Empty;
                l.PlanSerial ??= 0;
                l.Make = string.IsNullOrWhiteSpace(l.Make) ? "GEN" : l.Make;
                l.Qty = l.Qty;
                l.UnitPrice = l.UnitPrice;
                l.Discount = l.Discount;
                l.VatPercentage = l.VatPercentage;
                l.VatValue = l.VatValue;
                l.DiscountValue = l.DiscountValue;
                l.TotalValue = l.TotalValue;

                l.CreateDt = today;
                l.CreateTm = now;
                l.CreateBy = string.Empty;
                l.CreateRemarks = string.Empty;
                l.UpdateDt = today;
                l.UpdateTm = now;
                l.UpdateBy = string.Empty;
                l.UpdateRemarks = string.Empty;
            }

            var created = await _repo.AddAsync(header, lines, ct);
            _log.Info("Created PO {Fran}/{Branch}/{Wh}/{Type}/{No}", created.Fran, created.Branch, created.WarehouseCode, created.PoType, created.PoNumber);
            return ToDto(created);
        }

        public async Task<PurchaseOrderDto?> UpdateAsync(string fran, string branch, string warehouseCode, string poType, string poNumber, PurchaseOrderDto dto, CancellationToken ct)
        {
            dto.Fran = fran; dto.Branch = branch; dto.WarehouseCode = warehouseCode; dto.PoType = poType; dto.PoNumber = poNumber;
            var header = ToEntityHeader(dto);
            var lines = dto.Lines.Select(ToEntityLine).ToList();

            // Update audit
            var today = DateOnly.FromDateTime(DateTime.UtcNow);
            var now = DateTime.UtcNow;
            header.UpdateDt = today;
            header.UpdateTm = now;
            header.UpdateBy = string.Empty;
            header.UpdateRemarks = string.Empty;

            foreach (var l in lines)
            {
                l.PlanType = l.PlanType ?? string.Empty;
                l.PlanNo = l.PlanNo ?? string.Empty;
                l.PlanSerial ??= 0;
                l.Make = string.IsNullOrWhiteSpace(l.Make) ? "GEN" : l.Make;

                // ensure created fields are valid for NOT NULL columns during updates as well
                l.CreateDt = today;
                l.CreateTm = now;
                l.CreateBy = string.Empty;
                l.CreateRemarks = string.Empty;
                l.UpdateDt = today;
                l.UpdateTm = now;
                l.UpdateBy = string.Empty;
                l.UpdateRemarks = string.Empty;
            }
            var updated = await _repo.UpdateAsync(header, lines, ct);
            if (updated is null)
            {
                _log.Warn("PO not found for update {Fran}/{Branch}/{Wh}/{Type}/{No}", fran, branch, warehouseCode, poType, poNumber);
                return null;
            }
            _log.Info("Updated PO {Fran}/{Branch}/{Wh}/{Type}/{No}", fran, branch, warehouseCode, poType, poNumber);
            return ToDto(updated);
        }

        public Task<bool> DeleteAsync(string fran, string branch, string warehouseCode, string poType, string poNumber, CancellationToken ct)
            => _repo.DeleteAsync(fran, branch, warehouseCode, poType, poNumber, ct);

        private static PurchaseOrderDto ToDtoHeaderOnly(PurchaseOrder e) => new()
        {
            Fran = e.Fran,
            Branch = e.Branch,
            WarehouseCode = e.WarehouseCode,
            PoType = e.PoType,
            PoNumber = e.PoNumber,
            PoDate = e.PoDate.ToString("yyyy-MM-dd"),
            SupplierCode = e.SupplierCode,
            SupplierRefNo = e.SupplierRefNo,
            Currency = e.Currency,
            NoOfItems = (int)e.NoOfItems,
            Discount = e.Discount,
            TotalValue = e.TotalValue
        };

        private static PurchaseOrderDto ToDto(PurchaseOrder e)
        {
            var dto = ToDtoHeaderOnly(e);
            dto.Lines = e.Lines.Select(l => new PurchaseOrderLineDto
            {
                Fran = l.Fran,
                Branch = l.Branch,
                WarehouseCode = l.WarehouseCode,
                PoType = l.PoType,
                PoNumber = l.PoNumber,
                PoLineNumber = l.PoLineNumber,
                PoDate = l.PoDate.ToString("yyyy-MM-dd"),
                SupplierCode = l.SupplierCode,
                PlanType = l.PlanType,
                PlanNo = l.PlanNo,
                PlanSerial = l.PlanSerial.HasValue ? (long?)decimal.ToInt64(l.PlanSerial.Value) : null,
                Make = l.Make,
                PartCode = l.PartCode,
                Qty = l.Qty,
                UnitPrice = l.UnitPrice,
                Discount = l.Discount,
                VatPercentage = l.VatPercentage,
                VatValue = l.VatValue,
                DiscountValue = l.DiscountValue,
                TotalValue = l.TotalValue
            }).ToList();
            return dto;
        }

        private static PurchaseOrder ToEntityHeader(PurchaseOrderDto dto) => new()
        {
            Fran = dto.Fran,
            Branch = dto.Branch,
            WarehouseCode = dto.WarehouseCode,
            PoType = dto.PoType,
            PoNumber = dto.PoNumber,
            PoDate = DateOnly.Parse(dto.PoDate),
            SupplierCode = dto.SupplierCode,
            SupplierRefNo = dto.SupplierRefNo ?? string.Empty,
            Currency = dto.Currency,
            NoOfItems = dto.NoOfItems,
            Discount = dto.Discount,
            TotalValue = dto.TotalValue
        };

        private static PurchaseOrderLine ToEntityLine(PurchaseOrderLineDto dto) => new()
        {
            Fran = dto.Fran,
            Branch = dto.Branch,
            WarehouseCode = dto.WarehouseCode,
            PoType = dto.PoType,
            PoNumber = dto.PoNumber,
            PoLineNumber = dto.PoLineNumber,
            PoDate = DateOnly.Parse(dto.PoDate),
            SupplierCode = dto.SupplierCode,
            PlanType = dto.PlanType ?? string.Empty,
            PlanNo = dto.PlanNo ?? string.Empty,
            PlanSerial = dto.PlanSerial.HasValue ? (decimal?)dto.PlanSerial.Value : null,
            Make = dto.Make ?? string.Empty,
            PartCode = dto.PartCode,
            Qty = dto.Qty,
            UnitPrice = dto.UnitPrice,
            Discount = dto.Discount,
            VatPercentage = dto.VatPercentage,
            VatValue = dto.VatValue,
            DiscountValue = dto.DiscountValue,
            TotalValue = dto.TotalValue
        };
    }
}