using Microsoft.AspNetCore.Http;

namespace to_do_listServer.ViewModels
{
    public class FileView
    {
        public IFormFile File { get; set; }
        public string Source { get; set; }
        public long Size { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string Extension { get; set; }
    }
}