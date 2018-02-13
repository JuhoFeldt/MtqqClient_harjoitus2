using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Threading.Tasks;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;
using System.Net;
using System;

namespace Publisher_pressure
{
    // Toimiva versio toimii kahdella eri solutionilla (temperature ja pressure)
    class Program
    {
        static void Main(string[] args)
        {
            MqttClient myClient;
            string topic = "measurements/pressure";
            while (true)
            {
                Random rand = new Random();
                double pressure = Math.Round(rand.NextDouble() + rand.Next(1000, 1100), 2);
                string message = "Pressure: "+pressure.ToString();


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
