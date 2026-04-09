using System;
using System.Collections.Generic;

namespace Plants.API;

public partial class TechMap
{
    public int IdMap { get; set; }

    public int IdProduct { get; set; }

    public int VersionNumber { get; set; }

    public string? Status { get; set; }

    public int CreatedBy { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual User CreatedByNavigation { get; set; } = null!;

    public virtual Product IdProductNavigation { get; set; } = null!;

    public virtual ICollection<ProductionBatch> ProductionBatches { get; set; } = new List<ProductionBatch>();

    public virtual ICollection<TechStep> TechSteps { get; set; } = new List<TechStep>();
}
