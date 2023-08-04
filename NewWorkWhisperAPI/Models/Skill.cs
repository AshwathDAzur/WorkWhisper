using System;
using System.Collections.Generic;

namespace NewWorkWhisperAPI.Models;

public partial class Skill
{
    public int SkillId { get; set; }

    public string Skill1 { get; set; } = null!;

    public string Proficiency { get; set; } = null!;

    public int UserUserId { get; set; }
}
