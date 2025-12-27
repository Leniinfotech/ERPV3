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
    /// <summary>Application service for Shipments.</summary>
    public sealed class ShipmentsService : IShipmentsService
    {
        private readonly IShipmentsRepository _repo;
        private readonly IAppLogger<ShipmentsService> _log;

        public ShipmentsService(IShipmentsRepository repo, IAppLogger<ShipmentsService> log)
        {
            _repo = repo;
            _log = log;
        }

        public async Task<IReadOnlyList<ShipmentDto>> GetAllAsync(CancellationToken ct)
        {
            var list = await _repo.GetAllAsync(ct);
            return list.Select(ToDto).ToList();
        }

        public async Task<ShipmentDto?> GetByKeyAsync(string fran, string branch, string warehouseCode, string shipmentType, string shipmentNumber, CancellationToken ct)
        {
            var entity = await _repo.GetByKeyAsync(fran, branch, warehouseCode, shipmentType, shipmentNumber, ct);
            return entity is null ? null : ToDto(entity);
        }

        public async Task<ShipmentDto> CreateAsync(ShipmentDto dto, CancellationToken ct)
        {
            var entity = ToEntity(dto);
            // Safe defaults
            var now = DateTime.UtcNow;
            var today = DateOnly.FromDateTime(now);
            entity.BlNumber ??= string.Empty;
            entity.BuyerCode ??= string.Empty;
            entity.ShippingStatus ??= string.Empty;
            entity.ShipCompanyCode ??= string.Empty;
            entity.Status ??= string.Empty;
            entity.ProdCountryCode ??= string.Empty;
            entity.VesselNo ??= string.Empty;
            entity.VesselName ??= string.Empty;
            entity.Sender ??= string.Empty;
            entity.InspectionDocNo ??= string.Empty;
            entity.LetterOfCreditNo ??= string.Empty;
            entity.NoOfItems = 0m;
            entity.SeaFreightCharges = 0m;
            entity.InsuranceCharges = 0m;
            entity.OdsCharges = 0m;
            entity.AddlCharges = 0m;
            entity.DiscountValue = 0m;
            entity.GrossValue = 0m;
            entity.NetValue = 0m;
            entity.VatValue = 0m;
            entity.TotalValue = 0m;
            entity.Eta = today;
            entity.PortArrivalDt = today;
            entity.BondedArrivalDt = today;
            entity.BlDate ??= today;
            entity.CreateDt = today;
            entity.CreateTm = now;
            entity.CreateBy = string.Empty;
            entity.CreateRemarks = string.Empty;
            entity.UpdateDt = today;
            entity.UpdateTm = now;
            entity.UpdateBy = string.Empty;
            entity.UpdateRemarks = string.Empty;

            var created = await _repo.AddAsync(entity, ct);
            _log.Info("Created Shipment {Fran}/{Branch}/{Wh}/{Type}/{No}", created.Fran, created.Branch, created.WarehouseCode, created.ShipmentType, created.ShipmentNumber);
            return ToDto(created);
        }

        public async Task<ShipmentDto?> UpdateAsync(string fran, string branch, string warehouseCode, string shipmentType, string shipmentNumber, ShipmentDto dto, CancellationToken ct)
        {
            dto.Fran = fran; dto.Branch = branch; dto.WarehouseCode = warehouseCode; dto.ShipmentType = shipmentType; dto.ShipmentNumber = shipmentNumber;
            var entity = ToEntity(dto);
            // ensure non-null updatable strings
            entity.BlNumber ??= string.Empty;
            entity.BuyerCode ??= string.Empty;
            entity.ShippingStatus ??= string.Empty;
            entity.ShipCompanyCode ??= string.Empty;
            var updated = await _repo.UpdateAsync(entity, ct);
            if (updated is null)
            {
                _log.Warn("Shipment not found for update {Fran}/{Branch}/{Wh}/{Type}/{No}", fran, branch, warehouseCode, shipmentType, shipmentNumber);
                return null;
            }
            _log.Info("Updated Shipment {Fran}/{Branch}/{Wh}/{Type}/{No}", fran, branch, warehouseCode, shipmentType, shipmentNumber);
            return ToDto(updated);
        }

        public Task<bool> DeleteAsync(string fran, string branch, string warehouseCode, string shipmentType, string shipmentNumber, CancellationToken ct)
            => _repo.DeleteAsync(fran, branch, warehouseCode, shipmentType, shipmentNumber, ct);

        private static Shipment ToEntity(ShipmentDto dto) => new()
        {
            Fran = dto.Fran,
            Branch = dto.Branch,
            WarehouseCode = dto.WarehouseCode,
            ShipmentType = dto.ShipmentType,
            ShipmentNumber = dto.ShipmentNumber,
            ShipmentDate = DateOnly.Parse(dto.ShipmentDate),
            SupplierCode = dto.SupplierCode,
            Currency = dto.Currency,
            BlNumber = dto.BlNumber,
            BlDate = string.IsNullOrWhiteSpace(dto.BlDate) ? null : DateOnly.Parse(dto.BlDate!),
            BuyerCode = dto.BuyerCode,
            ShippingStatus = dto.ShippingStatus,
            ShipCompanyCode = dto.ShipCompanyCode
        };

        private static ShipmentDto ToDto(Shipment e) => new()
        {
            Fran = e.Fran,
            Branch = e.Branch,
            WarehouseCode = e.WarehouseCode,
            ShipmentType = e.ShipmentType,
            ShipmentNumber = e.ShipmentNumber,
            ShipmentDate = e.ShipmentDate.ToString("yyyy-MM-dd"),
            SupplierCode = e.SupplierCode,
            Currency = e.Currency,
            BlNumber = e.BlNumber,
            BlDate = e.BlDate?.ToString("yyyy-MM-dd"),
            BuyerCode = e.BuyerCode,
            ShippingStatus = e.ShippingStatus,
            ShipCompanyCode = e.ShipCompanyCode
        };
    }
}