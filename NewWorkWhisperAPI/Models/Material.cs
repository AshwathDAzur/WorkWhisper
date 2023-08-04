using System;
using System.Collections.Generic;

namespace NewWorkWhisperAPI.Models;

public partial class Material
{
    public int MatId { get; set; }

    public string Material1 { get; set; } = null!;

    public string Topic { get; set; } = null!;

    public int WhisperTopicWtopicId { get; set; }
}
