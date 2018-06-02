using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQ.Client.Framing.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQConsumer
{
    class Program
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory()
            {

                //UserName = "disparador",
                //Password = "disparador",
                //VirtualHost = "/",
                //HostName = "kafkascacula.eastus.cloudapp.azure.com",
                //Port = 5672
            };
            factory.Uri = new Uri("amqp://disparador:disparador@kafkascacula.eastus.cloudapp.azure.com:5672/");

            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    String fila = "dotnet";
                    channel.QueueDeclare(fila, false, false, false, null);

                    var consumer = new QueueingBasicConsumer(channel);
                    channel.BasicConsume(fila, true, consumer);

                    while(true)
                    {
                        var ea = (BasicDeliverEventArgs)consumer.Queue.Dequeue();
                        var body = ea.Body;
                        var messsage = Encoding.UTF8.GetString(body);
                        Console.WriteLine("{1} Recebido: {0}", messsage, DateTime.Now.ToString());
                    }
                   
                }
            }
        }
    }
}
