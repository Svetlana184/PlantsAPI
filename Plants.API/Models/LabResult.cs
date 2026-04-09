using System;
using System.Collections.Generic;

namespace Plants.API;

public partial class LabResult
{
    public int IdResult { get; set; }

    public int IdTest { get; set; }

    public string ParameterName { get; set; } = null!;

    public decimal? NormMin { get; set; }

    public decimal? NormMax { get; set; }

    public decimal? ActualValue { get; set; }

    public string? Unit { get; set; }

    public virtual LabTest IdTestNavigation { get; set; } = null!;
}
