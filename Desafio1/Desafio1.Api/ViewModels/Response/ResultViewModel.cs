namespace Desafio1.ViewModels.Response;

public class ResultViewModel<T>
    where T : class
{
    public List<string> Messages { get; private set; } = [];
    public T Data { get; private set; }

    public ResultViewModel(T data)
    {
        Data = data;
    }
    public ResultViewModel(List<string> messages)
    {
        Messages= messages;
    }
    public ResultViewModel(string message)
    {
        Messages.Add(message);
    }
}