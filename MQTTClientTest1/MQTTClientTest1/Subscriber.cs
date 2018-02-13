using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace MQTTClientTest1
{
    class Subscriber
    {
        public void Subscribe(MqttClient myClient, string topic)
        {
            myClient.Subscribe(new String[] { topic, }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });
            System.Console.ReadLine();
        }
        // Multiple topics
        public void SubscribeMultiple(MqttClient myClient)
        {
            myClient.Subscribe(new String[] {"measurements/#"}, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });
            System.Console.ReadLine();
        }

        public void RegisterMessageReceived(MqttClient myClient)
        {
            myClient.MqttMsgPublishReceived += client_recievedMessage;
            

            string clientId = Guid.NewGuid().ToString();
            myClient.Connect(clientId);
        }
        // Multiple messages
        public void RegisterMessageReceivedMultiple(MqttClient myClient)
        {
            myClient.MqttMsgPublishReceived += client_recievedMessageMultiple;


            string clientId = Guid.NewGuid().ToString();
            myClient.Connect(clientId);
        }
        public void RegisterTemperatureReceived(MqttClient myClient)
        {
            myClient.MqttMsgPublishReceived += client_recievedMessageTemp;

            string clientId = Guid.NewGuid().ToString();
            myClient.Connect(clientId);
        }
        public void RegisterPressureReceived(MqttClient myClient)
        {
            myClient.MqttMsgPublishReceived += client_recievedMessagePressure;

            string clientId = Guid.NewGuid().ToString();
            myClient.Connect(clientId);
        }
        static void client_recievedMessage(object sender, MqttMsgPublishEventArgs e)
        {
            
            var message = System.Text.Encoding.Default.GetString(e.Message);
            System.Console.WriteLine("Message received: " + message);
        }
        static void client_recievedMessageTemp(object sender, MqttMsgPublishEventArgs e)
        {
            
            var message = System.Text.Encoding.Default.GetString(e.Message);
            System.Console.Write("Temperature: " + message+" ");
        }
        // Multiple messages
        static void client_recievedMessageMultiple(object sender, MqttMsgPublishEventArgs e)
        {
            
            
            var message = System.Text.Encoding.Default.GetString(e.Message);
            Console.WriteLine(message);




        }
        static void client_recievedMessagePressure(object sender, MqttMsgPublishEventArgs e)
        {
            // Handle message received
            var message = System.Text.Encoding.Default.GetString(e.Message);
            System.Console.Write("Pressure: " + message+"\n");
        }
    }
}
