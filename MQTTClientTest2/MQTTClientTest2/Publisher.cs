using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace MQTTClientTest2
{
    class Publisher
    {
        public bool jatka = true;

        public void Publish(MqttClient myClient, string topic)
        {
            while (jatka)
            {
                Console.WriteLine("Anna lähetettävä viesti: ");
                string message = Console.ReadLine();
                if (message == "exit")
                {
                    jatka = false;
                    
                    
                }
                else
                {
                    string address = "192.168.28.128";
                    myClient = new MqttClient(IPAddress.Parse(address));
                    string clientId = Guid.NewGuid().ToString();
                    myClient.Connect(clientId);
                    myClient.Publish(topic, Encoding.UTF8.GetBytes(message), MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE, true);
                }
            }
            
        }
        public void PublishTemperature(MqttClient myClient, string topic)
        {
            while (jatka)
            {
                Random rand = new Random();
                double temp = Math.Round(rand.NextDouble() + rand.Next(5, 20),2);
                string message = temp.ToString();
                
                
                string address = "192.168.28.128";
                myClient = new MqttClient(IPAddress.Parse(address));
                string clientId = Guid.NewGuid().ToString();
                myClient.Connect(clientId);
                myClient.Publish(topic, Encoding.UTF8.GetBytes(message), MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE, true);
                Thread.Sleep(1100);
                
            }

        }

        public void PublishPressure(MqttClient myClient, string topic)
        {
            while (jatka)
            {
                Random rand = new Random();
                double pressure = Math.Round(rand.NextDouble() + rand.Next(1000 , 1100),2);
                string message = pressure.ToString();


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
