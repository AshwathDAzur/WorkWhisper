using System;
using System.Collections.Generic;

namespace NewWorkWhisperAPI.Models;

public partial class Like
{
    public int LikeId { get; set; }

    public int Like1 { get; set; }

    public int WhisperWhispId { get; set; }

    public int UserUserId { get; set; }
}
