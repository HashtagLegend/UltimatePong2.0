using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PongWebservice.Model;

namespace PongWebservice.Controllers
{
    [Route("api/Achievement")]
    [ApiController]
    public class AchievmentController : ControllerBase
    {
        private const string connection = "Data Source=ponglegends.database.windows.net;Initial Catalog=PongDatabase;User ID=legendsadmin;Password=P@ssw0rd;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        // GET: api/Achievment
        [HttpGet]
        public IEnumerable<Achievement> Get()
        {
            {
                var result = new List<Achievement>();
                string sql = "select * from Achievement";
                using (SqlConnection databaseConnection = new SqlConnection(connection))
                {
                    databaseConnection.Open();
                    using (SqlCommand selectCommand = new SqlCommand(sql, databaseConnection))
                    {
                        using (SqlDataReader reader = selectCommand.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    string brugerID = reader.GetString(0);
                                    string firstWin = reader.GetString(1);
                                    string fiveWins = reader.GetString(2);
                                    string tenWins = reader.GetString(3);
                                    string twentyWins = reader.GetString(4);
                                    string aIFirstWin = reader.GetString(5);
                                    string aIFiveWins = reader.GetString(6);
                                    string aITenWins = reader.GetString(7);
                                    string aITwentyWins = reader.GetString(8);

                                    var achievement = new Achievement()
                                    {
                                        BrugerID = brugerID,
                                        FirstWin = firstWin,
                                        FiveWins = fiveWins,
                                        TenWins = tenWins,
                                        TwentyWins = twentyWins,
                                        AIFirstWin = aIFirstWin,
                                        AIFiveWins = aIFiveWins,
                                        AITenWins = aITenWins,
                                        AITwentyWins = aITwentyWins
                                    };

                                    result.Add(achievement);
                                }
                            }
                        }
                    }
                }

                return result;
            }
        }

        // GET: api/Achievment/5
        [HttpGet("{id}", Name = "GetAchievementByID")]
        public string GetAchievementByID(string id)
        {
            {
                string sql = "select * from Achievement " + $"where Bruger_Id = {id}";
                var returnAchievement = new Achievement();
                using (SqlConnection databaseConnection = new SqlConnection(connection))
                {
                    databaseConnection.Open();
                    using (SqlCommand selectCommand = new SqlCommand(sql, databaseConnection))
                    {
                        using (SqlDataReader reader = selectCommand.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    string brugerID = reader.GetString(0);
                                    string firstWin = reader.GetString(1);
                                    string fiveWins = reader.GetString(2);
                                    string tenWins = reader.GetString(3);
                                    string twentyWins = reader.GetString(4);
                                    string aIFirstWin = reader.GetString(5);
                                    string aIFiveWins = reader.GetString(6);
                                    string aITenWins = reader.GetString(7);
                                    string aITwentyWins = reader.GetString(8);

                                    var achievement = new Achievement()
                                    {
                                        BrugerID = brugerID,
                                        FirstWin = firstWin,
                                        FiveWins = fiveWins,
                                        TenWins = tenWins,
                                        TwentyWins = twentyWins,
                                        AIFirstWin = aIFirstWin,
                                        AIFiveWins = aIFiveWins,
                                        AITenWins = aITenWins,
                                        AITwentyWins = aITwentyWins
                                    };

                                    returnAchievement = achievement;
                                }
                            }
                        }
                    }
                }

                return returnAchievement.ToString();
            }
        }

        // POST: api/Achievment
        [HttpPost]
        static public void PostAchievement([FromBody] string ID)
        {
            string insertBruger = "INSERT into Achievement (Bruger_Id) VALUES (@Id)";

            SqlConnection connect = new SqlConnection(connection);
            using (SqlCommand insertCommand = new SqlCommand(insertBruger, connect))
            {
                connect.Open();
                insertCommand.Parameters.AddWithValue("@Id", ID);
                insertCommand.ExecuteNonQuery();
            }
        }

        // PUT: api/Achievment/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {

        }
    }
}
