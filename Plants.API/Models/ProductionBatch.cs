using System;
using System.Collections.Generic;

namespace Plants.API;

public partial class ProductionBatch
{
    public int IdBatch { get; set; }

    public string BatchNumber { get; set; } = null!;

    public int IdProduct { get; set; }

    public int IdRecipe { get; set; }

    public int IdMap { get; set; }

    public int? IdEquipment { get; set; }

    public decimal PlannedQuantity { get; set; }

    public decimal? ActualQuantity { get; set; }

    public string? Status { get; set; }

    public DateTime? StartedAt { get; set; }

    public DateTime? FinishedAt { get; set; }

    public int CreatedBy { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<BatchRawMaterial> BatchRawMaterials { get; set; } = new List<BatchRawMaterial>();

    public virtual ICollection<BatchStep> BatchSteps { get; set; } = new List<BatchStep>();

    public virtual User CreatedByNavigation { get; set; } = null!;

    public virtual ICollection<Deviation> Deviations { get; set; } = new List<Deviation>();

    public virtual ICollection<Event> Events { get; set; } = new List<Event>();

    public virtual Equipment? IdEquipmentNavigation { get; set; }

    public virtual TechMap IdMapNavigation { get; set; } = null!;

    public virtual Product IdProductNavigation { get; set; } = null!;

    public virtual Recipe IdRecipeNavigation { get; set; } = null!;

    public virtual ICollection<LabTest> LabTests { get; set; } = new List<LabTest>();
}
