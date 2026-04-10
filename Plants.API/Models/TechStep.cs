using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Plants.API;

public partial class TechStep
{
    public int IdStep { get; set; }

    public int IdMap { get; set; }

    public int StepOrder { get; set; }

    public string NameStep { get; set; } = null!;

    public string? Description { get; set; }

    public bool? IsMandatory { get; set; }
    [JsonIgnore]
    public virtual ICollection<BatchStep> BatchSteps { get; set; } = new List<BatchStep>();
    [JsonIgnore]
    public virtual ICollection<Deviation> Deviations { get; set; } = new List<Deviation>();
    [JsonIgnore]
    public virtual TechMap IdMapNavigation { get; set; } = null!;
    [JsonIgnore]
    public virtual ICollection<StepParameter> StepParameters { get; set; } = new List<StepParameter>();
}
