using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Legion_IX.Helpers
{
    public class AzureSignalR_Server: Hub
    {
        // Connection string: Endpoint=https://legionixsignalr.service.signalr.net;AccessKey=YQ3fm8a7lJUNiNdTLN/8yGAipzee0Mp3Jj62Ja1wi4k=;Version=1.0;
        // Connection string Key: YQ3fm8a7lJUNiNdTLN/8yGAipzee0Mp3Jj62Ja1wi4k=

        const string connectionURL = "https://legionixsignalr.service.signalr.net/clientHub";
        const string connectionURL2 = "Endpoint=https://legionixsignalr.service.signalr.net;AuthType=azure.msi;Version=1.0;";
        const string connectionKey = "YQ3fm8a7lJUNiNdTLN/8yGAipzee0Mp3Jj62Ja1wi4k=";

        HubConnection connection;

        public AzureSignalR_Server()
        {
            //CreateConnection1();
            CreateConnection2();

            RegisterHandler();

            connection.Closed += async (error) =>
            {
                MessageBox.Show("Connection closed unexpectedly", "Error", MessageBoxButtons.OK);
                await Task.Delay(5000); // Wait 5 seconds before attempting to restart
                await connection.StartAsync(); // Restart the connection
            };
        }


        public void CreateConnection1()
        {
            connection = new HubConnectionBuilder().
                WithUrl(connectionURL, accessKey => {

                    accessKey.AccessTokenProvider = () => Task.FromResult(connectionKey);

                }).
                Build();
        }


        public void CreateConnection2()
        {
            connection = new HubConnectionBuilder().
                WithUrl(connectionURL2).Build();
        }


        public void RegisterHandler()
        {

            connection.On<string>("MethodOnHub", message =>
            {
                MessageBox.Show(message, "-- CONNECTED --", MessageBoxButtons.OK);
            });

        }


        public async Task StartTheConnection()
        {
            await connection.StartAsync();

            MessageBox.Show("Connection Started", "-- CONNECTED --", MessageBoxButtons.OK);
        }


        public async Task InvokeHubMethod()
        {
            if (MessageBox.Show("Invoke HubMethod?", "Test?", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                await connection.InvokeAsync("MethodOnHub", "Implementation succesfull!");
                MessageBox.Show("Hub method invoked successfully!", "-- SUCCESS --", MessageBoxButtons.OK);
            }
        }


        [HubMethodName("MethodOnHub")]
        public void MethodOnHub(string message)
        {
            Clients.All.SendAsync("Receiving Message:", message);
        }
    }
}