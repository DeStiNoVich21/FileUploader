namespace FileUploader.Helpers
{
    using System.Collections.Generic;

    public static class FileTypeMapper
    {
        private static readonly Dictionary<string, FileType> MimeMappings = new Dictionary<string, FileType>
    {
        { "image/jpeg", FileType.Image },
        { "image/png", FileType.Image },
        { "audio/mpeg", FileType.Audio },
        { "audio/wav", FileType.Audio },
        { "video/mp4", FileType.Video },
        { "application/pdf", FileType.Document },
        { "application/zip", FileType.Archive },
        { "application/x-rar-compressed", FileType.Archive },
        { "application/x-msdownload", FileType.Executable },
        { "text/plain", FileType.Document },
        { "application/msword", FileType.Document },
        { "application/vnd.openxmlformats-officedocument.wordprocessingml.document", FileType.Document }
    };

        public static FileType GetFileType(string contentType)
        {
            return MimeMappings.TryGetValue(contentType, out var fileType) ? fileType : FileType.Other;
        }
        public static bool IsValidEnumValue<TEnum>(string value) where TEnum : struct
        {
            return Enum.TryParse(value, true, out TEnum _);
        }
    }
}

