using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Plants.API;

public partial class BatchParameter
{
    public int IdActual { get; set; }

    public int IdExecution { get; set; }

    public int IdParam { get; set; }

    public decimal ActualValue { get; set; }

    public DateTime? RecordedAt { get; set; }

    [JsonIgnore]

    public virtual BatchStep IdExecutionNavigation { get; set; } = null!;
    [JsonIgnore]
    public virtual StepParameter IdParamNavigation { get; set; } = null!;
}
