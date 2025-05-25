using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Domain.Models
{
    public enum FileType
    {
        MPEG,
        MP4,
        QuickTime,
        WEBM,
        WMV,
        M4V,
        AVI,
        MKV,
        PNG,
        JPEG,
        PDF,
        MP3,
        AAC,
        OGG,
        VORBIS,
        FLAC,
        WAV,
        AIFF,
        M4A,
        APE,
        TXT,
        CSV,
        GIF,
        TIFF,
        WEBP,
        HEIF,
        HEIC,
        AVIF
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
                "video/mpeg" => FileType.MPEG,
                "video/mp4" => FileType.MP4,
                "video/quicktime" => FileType.QuickTime,
                "video/webm" => FileType.WEBM,
                "video/x-msvideo" => FileType.AVI,
                "video/x-matroska" => FileType.MKV,
                "video/x-m4v" => FileType.M4V,
                "video/avi" => FileType.AVI,
                "image/gif" => FileType.GIF,
                "image/png" => FileType.PNG,
                "image/jpeg" => FileType.JPEG,
                "image/pjpeg" => FileType.JPEG,
                "image/webp" => FileType.WEBP,
                "image/heif" => FileType.HEIF,
                "image/heic" => FileType.HEIC,
                "image/avif" => FileType.AVIF,
                "application/pdf" => FileType.PDF,
                "audio/mpeg" => FileType.MP3,
                "audio/aac" => FileType.AAC,
                "audio/ogg" => FileType.OGG,
                "audio/flac" => FileType.FLAC,
                "audio/x-aiff" => FileType.AIFF,
                "audio/x-wav" => FileType.WAV,
                "audio/x-ape" => FileType.APE,
                "audio/x-m4a" => FileType.M4A,
                "audio/x-ogg" => FileType.OGG,
                "text/plain" => FileType.TXT,
                "text/csv" => FileType.CSV,
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
