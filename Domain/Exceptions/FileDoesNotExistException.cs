namespace FileStorage.Domain.Exceptions
{
    public class FileDoesNotExistException : DomainException
    {
        public FileDoesNotExistException(string name) : base($"Файл не найден: {name}")
        {

        }

        public FileDoesNotExistException(int id) : base($"Файл не найден: id = {id}")
        {

        }
    }
}
