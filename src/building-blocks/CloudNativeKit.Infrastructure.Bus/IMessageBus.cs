using System.Threading.Tasks;
using CloudNativeKit.Domain;
using Google.Protobuf;

namespace CloudNativeKit.Infrastructure.Bus
{
    public interface IMessageBus
    {
        Task PublishAsync<TMessage>(TMessage msg, params string[] channels) where TMessage : IIntegrationEvent, IMessage<TMessage>;
        Task SubscribeAsync<TMessage>(params string[] channels) where TMessage : IIntegrationEvent, IMessage<TMessage>, new();
    }
}
