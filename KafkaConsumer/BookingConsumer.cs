using Confluent.Kafka.Serialization;
using Confluent.Kafka;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KafkaConsumer
{
    public class BookingConsumer : IBookingConsumer
    {
        public void Listen(Action<string> message)
        {

            var config = new Dictionary<string, object>
            {
                { "group.id", "booking_consumer"},
                { "bootstrap.servers", "localhost:9092"},
                { "enable.auto.commit", "false"}
            };


            using (var consumer = new Consumer<Null, string>(config, null, new StringDeserializer(Encoding.UTF8)))
            {
                consumer.Subscribe("text.test");
                //consumer.OnMessage += Consumer_OnMessage;

                consumer.OnMessage += (_, msg) => {
                    message(msg.Value);
                };
                while(true)
                {
                    consumer.Poll(100);
                }

            };
        }

    }
}
