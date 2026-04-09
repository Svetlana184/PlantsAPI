using System;
using System.Collections.Generic;

namespace Plants.API;

public partial class LabTest
{
    public int IdTest { get; set; }

    public string TestNumber { get; set; } = null!;

    public int? IdRawMaterialBatch { get; set; }

    public int? IdProductionBatch { get; set; }

    public string? Status { get; set; }

    public int? AssignedTo { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? FinishedAt { get; set; }

    public string? Conclusion { get; set; }

    public string? Comment { get; set; }

    public virtual User? AssignedToNavigation { get; set; }

    public virtual ProductionBatch? IdProductionBatchNavigation { get; set; }

    public virtual RawMaterialBatch? IdRawMaterialBatchNavigation { get; set; }

    public virtual ICollection<LabResult> LabResults { get; set; } = new List<LabResult>();
}
