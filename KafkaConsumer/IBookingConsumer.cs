using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KafkaConsumer
{
    public interface IBookingConsumer
    {
        void Listen(Action<string> message);
    }
}
