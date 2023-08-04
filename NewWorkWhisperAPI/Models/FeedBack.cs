using System;
using System.Collections.Generic;

namespace NewWorkWhisperAPI.Models;

public partial class FeedBack
{
    public int FeedBackId { get; set; }

    public string FeedBack1 { get; set; } = null!;

    public DateTime Date { get; set; }

    public int SquadSquadId { get; set; }

    public int UserUserId { get; set; }
}
