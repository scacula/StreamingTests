using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KafkaDemo
{
    public interface IBookingConsumer
    {
        void Listen(Func<string> message);
    }
}
