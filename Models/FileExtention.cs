namespace FileStorage.Models
{
    public class FileExtention
    {
        public int ExtentionId { get; set; }
        public string Name { get; set; }
        public byte? Foto { get; set; }


        public ICollection <Files> files{ get; set; } // многие ко многим
    }
}
