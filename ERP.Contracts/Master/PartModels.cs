using System.Collections.Generic;

namespace ERP.Contracts.Master
{
    public sealed record CreatePartRequest(string Code, string Description);
}