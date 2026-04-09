using System;
using System.Collections.Generic;

namespace Plants.API;

public partial class RawMaterialBatch
{
    public int IdBatch { get; set; }

    public string BatchNumber { get; set; } = null!;

    public int IdRawMaterial { get; set; }

    public decimal Quantity { get; set; }

    public string? Status { get; set; }

    public virtual ICollection<BatchRawMaterial> BatchRawMaterials { get; set; } = new List<BatchRawMaterial>();

    public virtual RawMaterial IdRawMaterialNavigation { get; set; } = null!;

    public virtual ICollection<LabTest> LabTests { get; set; } = new List<LabTest>();
}
