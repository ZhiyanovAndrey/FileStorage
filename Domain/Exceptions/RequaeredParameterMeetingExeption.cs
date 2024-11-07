namespace FileStorage.Domain.Exceptions
{
    public class RequaeredParameterMeetingExeption:DomainException
    {
        public RequaeredParameterMeetingExeption(string name):base($"Отсутствует обязательный параметр: {name}")
        {
           
        }
    }
}
