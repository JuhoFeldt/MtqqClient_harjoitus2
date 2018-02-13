using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Threading.Tasks;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;
using System.Net;

namespace Publisher_temperature
{
    class Program
    {
        static void Main(string[] args)
        {
            MqttClient myClient;
            string topic = "measurements/temperature";
            while (true)
            {
                Random rand = new Random();
                double temp = Math.Round(rand.NextDouble() + rand.Next(5, 20), 2);
                string message = "Temperature: "+temp.ToString();


                string address = "192.168.28.128";
                myClient = new MqttClient(IPAddress.Parse(address));
                string clientId = Guid.NewGuid().ToString();
                myClient.Connect(clientId);
                myClient.Publish(topic, Encoding.UTF8.GetBytes(message), MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE, true);
                Thread.Sleep(1000);

            }
        }
    }
}
