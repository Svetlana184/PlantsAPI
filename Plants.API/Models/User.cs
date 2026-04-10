using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

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
    [JsonIgnore]
    public virtual ICollection<BatchStep> BatchStepFinishedByNavigations { get; set; } = new List<BatchStep>();
    [JsonIgnore]
    public virtual ICollection<BatchStep> BatchStepStartedByNavigations { get; set; } = new List<BatchStep>();
    [JsonIgnore]
    public virtual ICollection<Event> Events { get; set; } = new List<Event>();
    [JsonIgnore]
    public virtual Department IdDepartmentNavigation { get; set; } = null!;
    [JsonIgnore]
    public virtual ICollection<LabTest> LabTests { get; set; } = new List<LabTest>();
    [JsonIgnore]
    public virtual ICollection<ProductionBatch> ProductionBatches { get; set; } = new List<ProductionBatch>();
    [JsonIgnore]
    public virtual ICollection<Recipe> Recipes { get; set; } = new List<Recipe>();
    [JsonIgnore]
    public virtual ICollection<TechMap> TechMaps { get; set; } = new List<TechMap>();
}
