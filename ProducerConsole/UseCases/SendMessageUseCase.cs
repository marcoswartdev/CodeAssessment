using ProducerConsole.Repositories;

namespace ProducerConsole.UseCases;

public class SendMessageUseCase
{
    private readonly ISendMessageRepository _sendMessageRepository;

    public SendMessageUseCase(ISendMessageRepository sendMessageRepository)
    {
        _sendMessageRepository = sendMessageRepository;
    }

    public void Execute(string name)
    {
        var message = $"Hello my name is, {name}";
        _sendMessageRepository.SendMessage(message);
    }
}
