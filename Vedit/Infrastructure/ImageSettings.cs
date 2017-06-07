using System;

namespace Vedit.Infrastructure
{
    [Serializable]
    public class ImageSettings
    {
        public int Width { get; set; } = 300;
        public int Height { get; set; } = 300;
    }
}