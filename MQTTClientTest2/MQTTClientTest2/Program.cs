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
    class Program
    {
        static void Main(string[] args)
        {
            Publisher pub1 = new MQTTClientTest2.Publisher();
            Publisher pub2 = new MQTTClientTest2.Publisher();
            string address = "192.168.28.128";
            MqttClient myClient = new MqttClient(IPAddress.Parse(address));
            pub1.PublishTemperature(myClient, "measurements/temperature");
            pub2.PublishPressure(myClient, "measurements/pressure");


        }
    }
}
