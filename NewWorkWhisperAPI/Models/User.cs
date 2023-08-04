using System;
using System.Collections.Generic;

namespace NewWorkWhisperAPI.Models;

public partial class User
{
    public int UserId { get; set; }

    public string UserName { get; set; } = null!;

    public string Nickname { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int Age { get; set; }

    public string Address { get; set; } = null!;

    public int Phone { get; set; }

    public int RoleRoleId { get; set; }
}
