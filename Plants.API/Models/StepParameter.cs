using System;
using System.Collections.Generic;

namespace Plants.API;

public partial class StepParameter
{
    public int IdParam { get; set; }

    public int IdStep { get; set; }

    public string NameParam { get; set; } = null!;

    public decimal TargetValue { get; set; }

    public decimal MinValue { get; set; }

    public decimal MaxValue { get; set; }

    public string? Unit { get; set; }

    public virtual ICollection<BatchParameter> BatchParameters { get; set; } = new List<BatchParameter>();

    public virtual TechStep IdStepNavigation { get; set; } = null!;
}
