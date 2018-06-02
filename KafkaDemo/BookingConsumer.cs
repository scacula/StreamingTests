using KafkaNet;
using Confluence.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KafkaDemo
{
    public class BookingConsumer : IBookingConsumer
    {
        public void Listen(Func<string> message)
        {

            var config = new Dictionary<string, object>
            {
                { "group.id", "booking_consumer"},
                { "bootstrap.servers", "localhost:9092"},
                { "enable.auto.commit", "false"}
            };


            using (var consumer = new Consumer<null, string>(config, null, new StringDeserializer())
            {

            }
        }
    }
}
