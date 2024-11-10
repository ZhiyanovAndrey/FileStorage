namespace FileStorage.Domain.Exceptions
{
    public class FolderDoesNotExistException:DomainException
    {
        public FolderDoesNotExistException(string name) : base($"Папка не найдена: {name}")
        {

        }

        public FolderDoesNotExistException(int id) : base($"Папка не найдена: id = {id}")
        {

        }
    }
}
