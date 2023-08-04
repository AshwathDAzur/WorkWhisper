using System;
using System.Collections.Generic;

namespace NewWorkWhisperAPI.Models;

public partial class Whisper
{
    public int WhispId { get; set; }

    public string WhisperContent { get; set; } = null!;

    public int SquadSquadId { get; set; }

    public int UserUserId { get; set; }

    public int WhisperTopicWtopicId { get; set; }

    public int WhisperTypeWtypeId { get; set; }
}
