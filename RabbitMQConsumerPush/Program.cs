using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQConsumerPush
{
    class Program
    {
        static void Main(string[] args)
        {

            var factory = new ConnectionFactory();
            factory.Uri = new Uri("amqp://disparador:disparador@kafkascacula.eastus.cloudapp.azure.com:5672/");

            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    String fila = "dotnet";

                    var consumer = new EventingBasicConsumer(channel);
                    consumer.Received += (ch, ea) =>
                    {
                        var body = ea.Body;

                        var messsage = Encoding.UTF8.GetString(body);
                        Console.WriteLine("{1} Recebido: {0}", messsage, DateTime.Now.ToString());

                        // ... process the message
                        channel.BasicAck(ea.DeliveryTag, false);
                    };
                    String consumerTag = channel.BasicConsume(fila, false, consumer);

                    while (true)
                    {

                    }


                }
            }




        }
    }
}
