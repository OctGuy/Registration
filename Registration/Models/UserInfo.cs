using System;
using System.Collections.Generic;

namespace Registration.Models;

public partial class UserInfo
{
    public int Id { get; set; }

    public string? FullName { get; set; }

    public string? PassWd { get; set; }
}
