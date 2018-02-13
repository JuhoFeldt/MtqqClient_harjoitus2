using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

// including the M2Mqtt Library
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace MQTTClientTest1
{
    class Program
    {
        static void Main(string[] args)
        {
            Publisher pub = new Publisher();
            Subscriber sub = new Subscriber();
            Subscriber sub1 = new Subscriber();
            Subscriber sub2 = new Subscriber();
            System.Console.WriteLine("start");
            // Create Client instance
            string address = "192.168.28.128";
            MqttClient myClient = new MqttClient(IPAddress.Parse(address));


            // Register to message received
            //sub.RegisterMessageReceived(myClient);
            //sub1.RegisterTemperatureReceived(myClient);
            //sub2.RegisterPressureReceived(myClient);

            
            sub.RegisterMessageReceivedMultiple(myClient);

            // Subscribe to topic
            //sub.Subscribe(myClient, "test");
            //sub1.Subscribe(myClient, "measurements/temperature");
            //sub2.Subscribe(myClient, "measurements/pressure");

            sub.SubscribeMultiple(myClient);

            // Publish message
            //pub.Publish(myClient, "test", "hello");




        }


        static void client_recievedMessage(object sender, MqttMsgPublishEventArgs e)
        {
            // Handle message received
            var message = System.Text.Encoding.Default.GetString(e.Message);
            System.Console.WriteLine("Message received: " + message);
        }
    }
}
