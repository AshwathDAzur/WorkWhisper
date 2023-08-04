using System;
using System.Collections.Generic;

namespace NewWorkWhisperAPI.Models;

public partial class WhisperTopic
{
    public int WtopicId { get; set; }

    public string Topic { get; set; } = null!;
}
