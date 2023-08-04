using System;
using System.Collections.Generic;

namespace NewWorkWhisperAPI.Models;

public partial class Notification
{
    public int NotiId { get; set; }

    public string Notiication { get; set; } = null!;

    public int UserUserId { get; set; }
}
