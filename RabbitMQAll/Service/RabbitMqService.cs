using RabbitMQ.Client;
using System.Text;
using Newtonsoft.Json;

namespace RabbitMQAll.Service
{
    public class RabbitMqService : IRabbitMqService
    {

        public void SendProductMessage<T>(T message)
        {
            var factory = new ConnectionFactory();

            factory.HostName = "10.0.0.15";
            //factory.Port = 15672;
            factory.UserName = "adi";
            factory.Password = "123!@#";
            factory.VirtualHost = "/";



            var connected = factory.CreateConnection();
            using var channel = connected.CreateModel();
            channel.QueueDeclare("Invoce",
                     durable: false,
                     exclusive: false,
                     autoDelete: false,
                     arguments: null
                );

            var json = JsonConvert.SerializeObject(message);
            var body = Encoding.UTF8.GetBytes(json);
            channel.BasicPublish(exchange: string.Empty, routingKey: "Invoce", body: body);

        }
    }
}
