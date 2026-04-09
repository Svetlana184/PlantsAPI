using System;
using System.Collections.Generic;

namespace Plants.API;

public partial class User
{
    public int IdUser { get; set; }

    public string FirstName { get; set; } = null!;

    public string? SecondName { get; set; }

    public string LastName { get; set; } = null!;

    public string Login { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public string Role { get; set; } = null!;

    public int IdDepartment { get; set; }

    public virtual ICollection<BatchStep> BatchStepFinishedByNavigations { get; set; } = new List<BatchStep>();

    public virtual ICollection<BatchStep> BatchStepStartedByNavigations { get; set; } = new List<BatchStep>();

    public virtual ICollection<Event> Events { get; set; } = new List<Event>();

    public virtual Department IdDepartmentNavigation { get; set; } = null!;

    public virtual ICollection<LabTest> LabTests { get; set; } = new List<LabTest>();

    public virtual ICollection<ProductionBatch> ProductionBatches { get; set; } = new List<ProductionBatch>();

    public virtual ICollection<Recipe> Recipes { get; set; } = new List<Recipe>();

    public virtual ICollection<TechMap> TechMaps { get; set; } = new List<TechMap>();
}
