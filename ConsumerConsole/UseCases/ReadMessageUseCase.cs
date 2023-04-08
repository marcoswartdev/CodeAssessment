using Receiver.Repositories;
using System.Text.RegularExpressions;

namespace Receiver.UseCases;

public class ReadMessageUseCase
{
    private readonly IReadMessageRepository _readMessageRepository;

    public ReadMessageUseCase(IReadMessageRepository readMessageRepository)
    {
        _readMessageRepository = readMessageRepository;
    }

    private bool ValidateName(string name)
    {
        Regex namePattern = new Regex(@"^[a-zA-Z]+(?:[\s]+[a-zA-Z]+)*$");
        return namePattern.IsMatch(name);
    }

    private string ExtractNameFromMessage(string message)
    {
        return message.Substring(message.LastIndexOf(',') + 1).Trim();
    }

    public void Execute(Action<string> callback)
    {
        _readMessageRepository.ReadMessage((message) =>
        {
            var name = ExtractNameFromMessage(message);
            bool isNameValid = ValidateName(name);
            if (isNameValid) callback($"Hello {name}, I am your father!");
            else callback($"{name} is not a valid name");
        });
    }
}
