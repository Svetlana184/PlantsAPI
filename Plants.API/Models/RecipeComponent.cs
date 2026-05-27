using System;
using System.Collections.Generic;

namespace Plants.API.Models;

public partial class RecipeComponent
{
    public int IdRecord { get; set; }

    public int IdRecipe { get; set; }

    public int IdRawMaterial { get; set; }

    public decimal Percentage { get; set; }

    public int LoadingOrder { get; set; }

    public virtual RawMaterial IdRawMaterialNavigation { get; set; } = null!;

    public virtual Recipe IdRecipeNavigation { get; set; } = null!;
}
