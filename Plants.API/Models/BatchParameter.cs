using System;
using System.Collections.Generic;

namespace Plants.API.Models;

public partial class BatchParameter
{
    public int IdActual { get; set; }

    public int IdExecution { get; set; }

    public int IdParam { get; set; }

    public decimal ActualValue { get; set; }

    public DateTime? RecordedAt { get; set; }

    public virtual BatchStep IdExecutionNavigation { get; set; } = null!;

    public virtual StepParameter IdParamNavigation { get; set; } = null!;
}
