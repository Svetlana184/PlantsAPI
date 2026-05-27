using System;
using System.Collections.Generic;

namespace Plants.API.Models;

public partial class Department
{
    public int IdDepartment { get; set; }

    public string NameDepartment { get; set; } = null!;

    public int? IdParentDepartment { get; set; }

    public virtual Department? IdParentDepartmentNavigation { get; set; }

    public virtual ICollection<Department> InverseIdParentDepartmentNavigation { get; set; } = new List<Department>();

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
