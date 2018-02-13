using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace MQTTClientTest1
{
    class Publisher
    {
        public void Publish(MqttClient myClient, string topic, string message)
        {

            string address = "192.168.28.128";
            myClient = new MqttClient(IPAddress.Parse(address));
            string clientId = Guid.NewGuid().ToString();
            myClient.Connect(clientId);
            myClient.Publish(topic, Encoding.UTF8.GetBytes(message), MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE, true);
        }


    }
}
