namespace ERP.Contracts.Master
{
    /// <summary>Represents a Part master record.</summary>
    public sealed class PartDto
    {
        /// <summary>Part code (business key).</summary>
        public string PartCode { get; set; } = null!;
        /// <summary>Description.</summary>
        public string? Description { get; set; }
        public string? Make { get; set; }
        public bool Active { get; set; }

        // ADD THESE:
        public string? Category { get; set; }
        public string? SubsPart { get; set; }
        public string? FinalPart { get; set; }
    }

    // Added: Added to store data
    // Added by: Vaishnavi
    // Added on: 10-12-2025
    // Request model for creating a part
    public sealed class PartRequests
    {
        public string Fran { get; set; } = null!;
        public string Make { get; set; } = null!;
        public string PartCode { get; set; } = null!;
        public string? Description { get; set; }
        public string InvClass { get; set; } = null!;
        public string Category { get; set; } = null!;
        public string Group { get; set; } = null!;
        public string Coo { get; set; } = null!;
    }

}