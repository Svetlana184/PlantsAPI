using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Plants.API;

public partial class RecipeComponent
{
    public int IdRecord { get; set; }

    public int IdRecipe { get; set; }

    public int IdRawMaterial { get; set; }

    public decimal Percentage { get; set; }

    public int LoadingOrder { get; set; }
    [JsonIgnore]
    public virtual RawMaterial IdRawMaterialNavigation { get; set; } = null!;
    [JsonIgnore]
    public virtual Recipe IdRecipeNavigation { get; set; } = null!;
}
