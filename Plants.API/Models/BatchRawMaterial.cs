using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Plants.API;

public partial class BatchRawMaterial
{
    public int IdRecord { get; set; }

    public int IdProductionBatch { get; set; }

    public int IdRawMaterialBatch { get; set; }

    public decimal Quantity { get; set; }
    [JsonIgnore]
    public virtual ProductionBatch IdProductionBatchNavigation { get; set; } = null!;
    [JsonIgnore]
    public virtual RawMaterialBatch IdRawMaterialBatchNavigation { get; set; } = null!;
}
