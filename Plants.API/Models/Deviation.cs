using System;
using System.Collections.Generic;

namespace Plants.API.Models;

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

    public virtual ProductionBatch IdProductionBatchNavigation { get; set; } = null!;

    public virtual TechStep? IdStepNavigation { get; set; }
}
