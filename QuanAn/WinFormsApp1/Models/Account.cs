using System;
using System.Collections.Generic;

namespace WinFormsApp1.Models;

public partial class Account
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Username { get; set; }

    public string? Password { get; set; }

    public string? Phone { get; set; }

    public int? Role { get; set; }
}
