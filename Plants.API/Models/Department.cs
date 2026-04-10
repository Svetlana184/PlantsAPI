using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Plants.API;

public partial class Department
{
    public int IdDepartment { get; set; }

    public string NameDepartment { get; set; } = null!;

    public int? IdParentDepartment { get; set; }
    [JsonIgnore]
    public virtual Department? IdParentDepartmentNavigation { get; set; }
    [JsonIgnore]
    public virtual ICollection<Department> InverseIdParentDepartmentNavigation { get; set; } = new List<Department>();
    [JsonIgnore]
    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
