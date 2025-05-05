using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Domain.Models
{
    public enum FileType
    {
        PNG,
        JPEG,
        PDF,
        MP3,
    }
    public class UserFile
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public FileType FileType { get; set; }
        public long Size { get; set; }
    }
}
