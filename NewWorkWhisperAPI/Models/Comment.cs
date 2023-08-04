using System;
using System.Collections.Generic;

namespace NewWorkWhisperAPI.Models;

public partial class Comment
{
    public int CommentId { get; set; }

    public string Comments { get; set; } = null!;

    public int WhisperWhispId { get; set; }

    public int UserUserId { get; set; }
}
