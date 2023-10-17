﻿using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

var factory = new ConnectionFactory();

factory.HostName = "10.0.0.15";
//factory.Port = 15672;
factory.UserName = "adi";
factory.Password = "123!@#";
factory.VirtualHost = "/";


var connection = factory.CreateConnection();

using var channel = connection.CreateModel();

channel.QueueDeclare("Invoce",
                durable: false,
                exclusive: false,
                autoDelete: false,
                arguments: null
           );

var consumer = new EventingBasicConsumer(channel);
consumer.Received += (model, eventArgs) =>
{
    var body = eventArgs.Body.ToArray();
    var message = Encoding.UTF8.GetString(body);
    Console.WriteLine($"Invoce message received: {message}");
};

channel.BasicConsume(queue: "Invoce", autoAck: true, consumer: consumer);
Console.ReadKey();