using System;
using System.Collections.Generic;

namespace NewWorkWhisperAPI.Models;

public partial class Status
{
    public int StatusId { get; set; }

    public string Status1 { get; set; } = null!;

    public int SquadSquadId { get; set; }
}
