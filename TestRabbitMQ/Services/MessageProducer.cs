using RabbitMQ.Client;
using System.Text;


namespace TestRabbitMQ.Services
{
    public class MessageProducer : IMessageProducer
    {
        public void SendingMessage<T>(T message)
        {
            var factory = new ConnectionFactory()
            {
                HostName = "localhost",
                UserName = "user",
                Password = "password",
                VirtualHost = "/"
            };

           
            using var connection =  factory.CreateConnection();
            using var channel = connection.CreateModel();

            channel.QueueDeclare(queue: "hello",
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

            
            var messageString = message?.ToString() ?? "Hello World!";
            var body = Encoding.UTF8.GetBytes(messageString);

          
            channel.BasicPublish(exchange: string.Empty,
                                 routingKey: "hello",
                                 basicProperties: null,
                                 body: body);

         
         
        }
    }
}
