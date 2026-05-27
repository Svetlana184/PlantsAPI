using System;
using System.Collections.Generic;

namespace Plants.API.Models;

public partial class TechStep
{
    public int IdStep { get; set; }

    public int IdMap { get; set; }

    public int StepOrder { get; set; }

    public string NameStep { get; set; } = null!;

    public string? Description { get; set; }

    public bool? IsMandatory { get; set; }

    public virtual ICollection<BatchStep> BatchSteps { get; set; } = new List<BatchStep>();

    public virtual ICollection<Deviation> Deviations { get; set; } = new List<Deviation>();

    public virtual TechMap IdMapNavigation { get; set; } = null!;

    public virtual ICollection<StepParameter> StepParameters { get; set; } = new List<StepParameter>();
}
