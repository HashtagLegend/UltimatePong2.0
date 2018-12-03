using System;
using System.ComponentModel;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PongControlsWebService.Model;

namespace ControlsUdpReciever
{
    class Program
    {
        private const int Port = 7250;
        static string gameUri = "https://ultimatepongcontrols.azurewebsites.net/api/direction";

        static string lastDirection = "";

        static void Main(string[] args)
        {
            //Oprettet en tom udpreciever, så der kan modtages UDP broadcasts, tager en Port som parameter
            UdpClient udpReciever = new UdpClient(Port);

            //IPEndpoint er den ipadresse der bliver sendt fra, altså den source der broadcaster
            IPEndPoint remoteIpEndPoint = new IPEndPoint(IPAddress.Any, Port);

            Console.WriteLine("Game not started");

            try
            {

                while (true)
                {
                    
                    Byte[] recieveBytes = udpReciever.Receive(ref remoteIpEndPoint);

                    string recievedData = Encoding.ASCII.GetString(recieveBytes);

                    //Console.WriteLine("Recieved: " + recievedData);

                    if (recievedData == "moving up" && (lastDirection != "moving up"))
                    {
                        SendControl("up");
                        Console.WriteLine("send up");
                        lastDirection = "moving up";
                    }

                    else if(recievedData == "moving down" && (lastDirection != "moving down"))
                    {
                        SendControl("down");
                        Console.WriteLine("send down");
                        lastDirection = "moving down";
                    }

                    else if (recievedData == "not moving" && (lastDirection != "not moving"))
                    {
                        SendControl("not moving");
                        Console.WriteLine("send stop");
                        lastDirection = "not moving";
                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        public static async Task<string> SendControl(String direction)
        {
            using (HttpClient client = new HttpClient())
            {
                var jsonString = JsonConvert.SerializeObject(direction);
                StringContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(gameUri, content);

                return response.ToString();

            }
        }


    }
}
