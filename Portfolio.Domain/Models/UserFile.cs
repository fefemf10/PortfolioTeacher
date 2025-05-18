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
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public FileType FileType { get; set; }
        public long Size { get; set; }
        public static FileType GetFileTypeFromMime(string contentType) =>
            contentType switch
            {
                "image/png" => FileType.PNG,
                "image/jpeg" => FileType.JPEG,
                "application/pdf" => FileType.PDF,
                "audio/mpeg" => FileType.MP3,
                _ => throw new NotImplementedException()
            };
        public static string GetMimeFromFileType(FileType fileType)
        {
            var fileTypeToMime = new Dictionary<FileType, string>
            {
                [FileType.PNG] = "image/png",
                [FileType.JPEG] = "image/jpeg",
                [FileType.PDF] = "application/pdf",
                [FileType.MP3] = "audio/mpeg",
            };
            return fileTypeToMime.TryGetValue(fileType, out var mime) ? mime : "application/octet-stream";
        }
    }
}
