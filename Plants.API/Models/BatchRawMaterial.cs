using System;
using System.Collections.Generic;

namespace Plants.API;

public partial class BatchRawMaterial
{
    public int IdRecord { get; set; }

    public int IdProductionBatch { get; set; }

    public int IdRawMaterialBatch { get; set; }

    public decimal Quantity { get; set; }

    public virtual ProductionBatch IdProductionBatchNavigation { get; set; } = null!;

    public virtual RawMaterialBatch IdRawMaterialBatchNavigation { get; set; } = null!;
}
