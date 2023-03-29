using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Food
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? IdCate { get; set; }

    public int? Price { get; set; }

    public virtual ICollection<BillInfo> BillInfos { get; } = new List<BillInfo>();

    public virtual Category? IdCateNavigation { get; set; }
}
