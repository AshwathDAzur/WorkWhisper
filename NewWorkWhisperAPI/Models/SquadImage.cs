using System;
using System.Collections.Generic;

namespace NewWorkWhisperAPI.Models;

public partial class SquadImage
{
    public int SqimgId { get; set; }

    public string SqimgUrl { get; set; } = null!;

    public int SquadSquadId { get; set; }
}
