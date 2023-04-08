using Sender.Repositories;

namespace Sender.UseCases;

public class SendMessageUseCase : ISendMessageUseCase
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
