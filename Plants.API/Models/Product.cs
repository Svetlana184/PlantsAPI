using System;
using System.Collections.Generic;

namespace Plants.API;

public partial class Product
{
    public int IdProduct { get; set; }

    public string Code { get; set; } = null!;

    public string NameProduct { get; set; } = null!;

    public string Type { get; set; } = null!;

    public string Form { get; set; } = null!;

    public string? Status { get; set; }

    public virtual ICollection<ProductionBatch> ProductionBatches { get; set; } = new List<ProductionBatch>();

    public virtual ICollection<Recipe> Recipes { get; set; } = new List<Recipe>();

    public virtual ICollection<TechMap> TechMaps { get; set; } = new List<TechMap>();
}
