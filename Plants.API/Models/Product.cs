using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Plants.API;

public partial class Product
{
    public int IdProduct { get; set; }

    public string Code { get; set; } = null!;

    public string NameProduct { get; set; } = null!;

    public string Type { get; set; } = null!;

    public string Form { get; set; } = null!;

    public string? Status { get; set; }
    [JsonIgnore]
    public virtual ICollection<ProductionBatch> ProductionBatches { get; set; } = new List<ProductionBatch>();
    [JsonIgnore]
    public virtual ICollection<Recipe> Recipes { get; set; } = new List<Recipe>();
    [JsonIgnore]
    public virtual ICollection<TechMap> TechMaps { get; set; } = new List<TechMap>();
}
