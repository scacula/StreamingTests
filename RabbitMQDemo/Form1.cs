using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RabbitMQDemo
{
    public partial class Form1 : Form
    {
        IConnection rabbitConnection;
        IModel rabbitChannel;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
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
                    String fila = txtFila.Text;
                    channel.QueueDeclare(fila, false, false, false, null);
                    string message = txtMsg1.Text;

                    var body = Encoding.UTF8.GetBytes(message);
                    channel.BasicPublish("", fila, null, body);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
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


            var connection = factory.CreateConnection();

            var channel = connection.CreateModel();
            
            String fila = txtFila.Text;
            channel.QueueDeclare(fila, false, false, false, null);

            rabbitChannel = channel;
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string message = txtMsg2.Text;
            String fila = txtFila.Text;

            var body = Encoding.UTF8.GetBytes(message);
            rabbitChannel.BasicPublish("", fila, null, body);
        }
    }
}
