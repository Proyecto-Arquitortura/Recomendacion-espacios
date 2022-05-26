using api_netcore_recommendacion_espacios.Data;
using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Client.Options;
using System;
using System.Threading.Tasks;

namespace api_netcore_recommendacion_espacios.Servicios
{
    public static class MqttPublisherService
    {
        private static IMqttClient _mqttClient;
        private static IMqttClientOptions _mqttClientOptions;

        public static async Task RunAsync()
        {
            try
            {
                var factory = new MqttFactory();
                var _repo = new MockEspaciosRepo();
                _repo.CreateData();
                _mqttClient = factory.CreateMqttClient();
                _mqttClientOptions = new MqttClientOptionsBuilder()
                    .WithClientId(Guid.NewGuid().ToString())
                    .WithTcpServer("10.43.102.27", port : 1883)
                    .WithCredentials("admin","1234")
                    .WithCleanSession()
                    .Build();
                _mqttClient.UseConnectedHandler(e =>
                {
                     Console.WriteLine("MQTT Connected");
         
                });
                _mqttClient.UseDisconnectedHandler(e =>
                {
                    Console.WriteLine("MQTT Disconnected");
                });
                await _mqttClient.ConnectAsync(_mqttClientOptions);
                //         - Get jsonString -        //
                string jsonString = _repo.ToJsonString();
                var testMessage = new MqttApplicationMessageBuilder()
                    .WithTopic("topic/espacio_rec")
                    .WithPayload(jsonString)
                    .WithExactlyOnceQoS()
                    .WithRetainFlag()
                    .Build();
                await _mqttClient.PublishAsync(testMessage);
                Console.WriteLine(jsonString);
                Console.WriteLine("Message Sent.");
                await _mqttClient.DisconnectAsync();

            }
            catch (Exception e)
            {
                Console.WriteLine(e);

            }

        }


    }
}
