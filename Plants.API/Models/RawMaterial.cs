using System;
using System.Collections.Generic;

namespace Plants.API.Models;

public partial class RawMaterial
{
    public int IdRawMaterial { get; set; }

    public string Code { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Unit { get; set; } = null!;

    public virtual ICollection<RawMaterialBatch> RawMaterialBatches { get; set; } = new List<RawMaterialBatch>();

    public virtual ICollection<RecipeComponent> RecipeComponents { get; set; } = new List<RecipeComponent>();
}
