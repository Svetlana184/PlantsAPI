using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Plants.API;

public partial class Deviation
{
    public int IdDeviation { get; set; }

    public int IdProductionBatch { get; set; }

    public int? IdStep { get; set; }

    public string ParameterName { get; set; } = null!;

    public decimal ExpectedValue { get; set; }

    public decimal ActualValue { get; set; }

    public string? Severity { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? ResolvedAt { get; set; }

    public string? ResolutionComment { get; set; }
    [JsonIgnore]
    public virtual ProductionBatch IdProductionBatchNavigation { get; set; } = null!;
    [JsonIgnore]
    public virtual TechStep? IdStepNavigation { get; set; }
}
