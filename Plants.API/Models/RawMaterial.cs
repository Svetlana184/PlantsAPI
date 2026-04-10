using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Plants.API;

public partial class RawMaterial
{
    public int IdRawMaterial { get; set; }

    public string Code { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Unit { get; set; } = null!;
    [JsonIgnore]
    public virtual ICollection<RawMaterialBatch> RawMaterialBatches { get; set; } = new List<RawMaterialBatch>();
    [JsonIgnore]
    public virtual ICollection<RecipeComponent> RecipeComponents { get; set; } = new List<RecipeComponent>();
}
