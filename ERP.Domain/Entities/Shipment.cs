namespace ERP.Domain.Entities;

public sealed class Shipment
{
    // Key: { FRAN, BRCH, WHSE, SINVTYPE, SINVNO }
    public string Fran { get; set; } = null!;
    public string Branch { get; set; } = null!;
    public string WarehouseCode { get; set; } = null!;
    public string ShipmentType { get; set; } = null!; // SINVTYPE
    public string ShipmentNumber { get; set; } = null!; // SINVNO

    public DateOnly ShipmentDate { get; set; } // SINVDT
    public string SupplierCode { get; set; } = null!;  // VENDOR
    public string Currency { get; set; } = null!;      // CURRENCY
    public string? BlNumber { get; set; }              // BLNO
    public DateOnly? BlDate { get; set; }              // BLDT
    public string? BuyerCode { get; set; }             // BUYERCODE
    public string? ShippingStatus { get; set; }        // SHIPPINGSTATUS
    public string? ShipCompanyCode { get; set; }       // SHIPCOMPANYCODE

    public string? Status { get; set; }                // STATUS
    public DateOnly Eta { get; set; }                  // ETA (date)
    public string? ProdCountryCode { get; set; }       // PRODCOUNTRYCODE
    public string? VesselNo { get; set; }              // VESSELNO
    public string? VesselName { get; set; }            // VESSELNAME
    public string? Sender { get; set; }                // SENDER
    public DateOnly PortArrivalDt { get; set; }        // PORTARRIVALDT (date)
    public DateOnly BondedArrivalDt { get; set; }      // BONDEDARRVALDT (date)

    // Important non-null / audit-ish fields we may need to satisfy inserts
    public decimal NoOfItems { get; set; }              // NOOFITEMS
    public decimal SeaFreightCharges { get; set; }     // SEAFREIGHTCHARGES
    public decimal InsuranceCharges { get; set; }      // INSURANCECHARGES
    public decimal OdsCharges { get; set; }            // ODSCHARGES
    public decimal AddlCharges { get; set; }           // ADDLCHARGES
    public string? InspectionDocNo { get; set; }       // INSPECTIONDOCNO
    public string? LetterOfCreditNo { get; set; }      // LETTEROFCREDITNO
    public decimal DiscountValue { get; set; }         // DISCOUNTVALUE
    public decimal GrossValue { get; set; }            // GROSSVALUE
    public decimal NetValue { get; set; }              // NETVALUE
    public decimal VatValue { get; set; }              // VATVALUE
    public decimal TotalValue { get; set; }            // TOTALVALUE
    public DateOnly CreateDt { get; set; }             // CREATEDT
    public DateTime CreateTm { get; set; }             // CREATETM
    public string CreateBy { get; set; } = string.Empty; // CREATEBY
    public string CreateRemarks { get; set; } = string.Empty; // CREATEREMARKS
    public DateOnly UpdateDt { get; set; }             // UPDATEDT
    public DateTime UpdateTm { get; set; }             // UPDATETM
    public string UpdateBy { get; set; } = string.Empty; // UPDATEBY
    public string UpdateRemarks { get; set; } = string.Empty; // UPDATEREMARKS

    // Nav
    public Supplier Supplier { get; set; } = null!;
}