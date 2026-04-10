using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Plants.API;

public partial class RawMaterialBatch
{
    public int IdBatch { get; set; }

    public string BatchNumber { get; set; } = null!;

    public int IdRawMaterial { get; set; }

    public decimal Quantity { get; set; }

    public string? Status { get; set; }
    [JsonIgnore]
    public virtual ICollection<BatchRawMaterial> BatchRawMaterials { get; set; } = new List<BatchRawMaterial>();
    [JsonIgnore]
    public virtual RawMaterial IdRawMaterialNavigation { get; set; } = null!;
    [JsonIgnore]
    public virtual ICollection<LabTest> LabTests { get; set; } = new List<LabTest>();
}
