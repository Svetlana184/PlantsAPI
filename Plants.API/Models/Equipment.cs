using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Plants.API;

public partial class Equipment
{
    public int IdEquipment { get; set; }

    public string Name { get; set; } = null!;

    public string Type { get; set; } = null!;

    public string? Status { get; set; }
    [JsonIgnore]
    public virtual ICollection<ProductionBatch> ProductionBatches { get; set; } = new List<ProductionBatch>();
}
