using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Bill
{
    public int Id { get; set; }

    public DateTime? DateCheckIn { get; set; }

    public DateTime? DateCheckOut { get; set; }

    public int? IdTable { get; set; }

    public int? TotalPrice { get; set; }

    public string? Phone { get; set; }

    public int? Status { get; set; }

    public virtual ICollection<BillInfo> BillInfos { get; } = new List<BillInfo>();

    public virtual TableFood? IdTableNavigation { get; set; }
}
