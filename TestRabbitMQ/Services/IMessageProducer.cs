namespace TestRabbitMQ.Services
{
    public interface IMessageProducer
    {
        void SendingMessage<T>(T message);
    }
}
