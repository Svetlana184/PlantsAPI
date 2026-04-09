using System;
using System.Collections.Generic;

namespace Plants.API;

public partial class BatchStep
{
    public int IdExecution { get; set; }

    public int IdProductionBatch { get; set; }

    public int IdStep { get; set; }

    public string? Status { get; set; }

    public int? StartedBy { get; set; }

    public DateTime? StartedAt { get; set; }

    public int? FinishedBy { get; set; }

    public DateTime? FinishedAt { get; set; }

    public string? Comment { get; set; }

    public virtual ICollection<BatchParameter> BatchParameters { get; set; } = new List<BatchParameter>();

    public virtual User? FinishedByNavigation { get; set; }

    public virtual ProductionBatch IdProductionBatchNavigation { get; set; } = null!;

    public virtual TechStep IdStepNavigation { get; set; } = null!;

    public virtual User? StartedByNavigation { get; set; }
}
