using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Threading;

namespace TestInput
{
    class Program
    {
        //Bruges kun til at simulerer input fra en controller, når der ikke er en Raspberry Pi til rådighed til at broadcaste.

        private static string gameUri = "https://ultimatepongcontrols.azurewebsites.net/api/direction";
        //private static string gameUri = "https://localhost:5001/api/direction";


        static void Main(string[] args)
        {
            for (int i = 0; i < 100000; i++)
            {
                Random rnd = new Random();

                int rand = rnd.Next(1, 4);

                if (rand == 1)
                {
                    SendControl("up");
                }

                else if (rand == 2)
                {
                    SendControl("down");
                }

                else if (rand == 3)
                {
                    SendControl("not moving");
                }

                Console.WriteLine(rand);
                //Thread.Sleep(1000);
            }

            Console.ReadKey();
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


