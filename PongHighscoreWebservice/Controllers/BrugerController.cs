using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Channels;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PongWebservice.Model;

namespace PongWebservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrugerController : ControllerBase
    {

        private const string connection = "Data Source=ponglegends.database.windows.net;Initial Catalog=PongDatabase;User ID=legendsadmin;Password=P@ssw0rd;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        // GET: api/Bruger
        [HttpGet]
        public IEnumerable<Bruger> GetBruger()
        {
            var result = new List<Bruger>();
            string sql = "select * from Bruger";
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
                                int id = reader.GetInt32(0);
                                string brugernavn = reader.GetString(1);
                                string description = reader.GetString(2);
                                int wins = reader.GetInt32(3);
                                int loses = reader.GetInt32(4);
                                int ai_wins = reader.GetInt32(5);
                                int ai_loses = reader.GetInt32(6);

                                var bruger = new Bruger()
                                {
                                    Id = id,
                                    Brugernavn = brugernavn,
                                    Description = description,
                                    Wins = wins,
                                    Loses = loses,
                                    AI_Wins = ai_wins,
                                    AI_Loses = ai_loses,
                                };

                                result.Add(bruger);
                            }
                        }
                    }
                }
            }

            return result;
        }

        // GET: api/Bruger/5
        [HttpGet("{id}", Name = "Get")]
        public string GetBrugerById(int id)
        {
            string sql = "select * from Bruger " +
                         $"where Bruger_Id = {id}";
            var brugerReturn = new Bruger();
            using (SqlConnection databaseConnection = new SqlConnection(connection))
            {
                databaseConnection.Open();
                using (SqlCommand selectCommand = new SqlCommand(sql, databaseConnection))
                {
                    using (SqlDataReader reader = selectCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int ID = reader.GetInt32(0);
                            string brugernavn = reader.GetString(1);
                            string description = reader.GetString(2);
                            int wins = reader.GetInt32(3);
                            int loses = reader.GetInt32(4);
                            int ai_wins = reader.GetInt32(5);
                            int ai_loses = reader.GetInt32(6);

                            var bruger = new Bruger()
                            {
                                Id = ID,
                                Brugernavn = brugernavn,
                                Description = description,
                                Wins = wins,
                                Loses = loses,
                                AI_Wins = ai_wins,
                                AI_Loses = ai_loses,
                            };

                            brugerReturn = bruger;
                        }

                    }
                }
            }

            return brugerReturn.ToString();
        }

        // POST: api/Bruger
        [HttpPost]
        public void PostBruger([FromBody] BrugerModel brugerModel)
        {
            string insertBruger = "INSERT into Bruger (Bruger_Id, Brugernavn) VALUES (@Id, @Brugernavn)";

            SqlConnection connect = new SqlConnection(connection);
            using (SqlCommand insertCommand = new SqlCommand(insertBruger, connect))
            {
                Console.WriteLine(brugerModel.ID + "  " + brugerModel.Brugernavn);
                connect.Open();
                insertCommand.Parameters.AddWithValue("@Id", brugerModel.ID);
                insertCommand.Parameters.AddWithValue("@Brugernavn", brugerModel.Brugernavn);
                insertCommand.ExecuteNonQuery();
            }

        }

        // PUT: api/Bruger/5
        [HttpPut("{id}")]
        public void PutBruger(int id, [FromBody] ScoreMaker scoreMaker)
        {
            string updateBruger = "ERROR";
            if (scoreMaker.Gamemode == "AI")
            {
                updateBruger = $"UPDATE Bruger SET AI_Wins_Total = AI_Wins_Total + {scoreMaker.Win}, AI_Loses_Total = AI_Loses_Total + {scoreMaker.Loss} WHERE Bruger_Id={id};";
            }
            else if (scoreMaker.Gamemode == "Multiplayer")
            {
                updateBruger = $"UPDATE Bruger SET Wins_Total = Wins_Total + {scoreMaker.Win}, Loses_Total = Loses_Total + {scoreMaker.Loss} WHERE Bruger_Id={id};";
            }
            else if (scoreMaker.Gamemode == "Brugernavn")
            {
                updateBruger = $"UPDATE Bruger SET Brugernavn = '{scoreMaker.Brugernavn}' WHERE Bruger_Id={id};";
            }
            else if (scoreMaker.Gamemode == "Description")
            {
                updateBruger = $"UPDATE Bruger SET Description = '{scoreMaker.Description}' WHERE Bruger_Id={id};";
            }

            //string updateBrugerAI = $"UPDATE Bruger (AI_Wins_Total, AI_Loses_Total) VALUES (@AI_Wins_Total, @AI_Loses_Total) WHERE Bruger_Id={id};";
            SqlConnection connect = new SqlConnection(connection);
            using (SqlCommand insertCommand = new SqlCommand(updateBruger, connect))
            {
                Console.WriteLine(scoreMaker.Id + "  " + scoreMaker.Gamemode);
                connect.Open();
                insertCommand.ExecuteNonQuery();
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            string insertBruger = $"DELETE FROM Bruger WHERE Bruger_Id = {id}";

            SqlConnection connect = new SqlConnection(connection);
            using (SqlCommand insertCommand = new SqlCommand(insertBruger, connect))
            {
                connect.Open();
                insertCommand.ExecuteNonQuery();
            }

        }
    }
}
