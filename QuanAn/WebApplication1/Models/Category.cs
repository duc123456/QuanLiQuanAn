using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Category
{
    public int Id { get; set; }

    public string? Category1 { get; set; }

    public virtual ICollection<Food> Foods { get; } = new List<Food>();
}
