using System;
using System.Collections.Generic;

namespace NewWorkWhisperAPI.Models;

public partial class Squad
{
    public int SquadId { get; set; }

    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime DeadLine { get; set; }
}
