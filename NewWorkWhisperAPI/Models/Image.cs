using System;
using System.Collections.Generic;

namespace NewWorkWhisperAPI.Models;

public partial class Image
{
    public int ImgId { get; set; }

    public string ImgUrl { get; set; } = null!;

    public int WhisperWhispId { get; set; }
}
