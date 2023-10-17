namespace RabbitMQAll.Service
{
    public interface IRabbitMqService
    {
        void SendProductMessage<T>(T message);
    }
}