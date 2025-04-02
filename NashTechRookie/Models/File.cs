namespace NashTechRookie.Models
{
    public class FileModel
    {
        public byte[] FileContent { get; set; }
        public string ContentType { get; set; }
        public string FileName { get; set; }
        public FileModel(byte[] fileContent, string contentType, string fileName)
        {
            FileContent = fileContent;
            ContentType = contentType;
            FileName = fileName;
        }
    }
}