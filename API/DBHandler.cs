using MySql.Data;
using MySql.Data.MySqlClient;
using System.Diagnostics;
using System.Xml.Linq;

namespace TriviaAPI
{
    
    public static class DBHandler
    {
        const string CON_STR = "Server=localhost; database=trivia; UID=root; password=root";
        static MySqlConnection conn;
        static MySqlCommand cmd;
        static MySqlDataReader reader;

        public static Question GetQuestion(int id)
        {
            Question q = new Question();

            try
            {
                Connect();
                string query = "SELECT QuestionText FROM trivia.questions WHERE QuestionId = " + id;
                cmd = new MySqlCommand(query, conn);

                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    q.text = reader.GetString(0);
                }

                Connect();
                query = "SELECT Answer1Text FROM trivia.questions WHERE QuestionId = " + id;
                cmd = new MySqlCommand(query, conn);

                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    q.ans1 = reader.GetString(0);
                }

                Connect();
                query = "SELECT Answer2Text FROM trivia.questions WHERE QuestionId = " + id;
                cmd = new MySqlCommand(query, conn);

                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    q.ans2 = reader.GetString(0);
                }

                Connect();
                query = "SELECT Answer3Text FROM trivia.questions WHERE QuestionId = " + id;
                cmd = new MySqlCommand(query, conn);

                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    q.ans3 = reader.GetString(0);
                }

                Connect();
                query = "SELECT Answer4Text FROM trivia.questions WHERE QuestionId = " + id;
                cmd = new MySqlCommand(query, conn);

                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    q.ans4 = reader.GetString(0);
                }

            }
            catch (Exception ex) { }

            Disconnect();
            return q;
        }

        public static Player GetPlayer(int id)
        {
            Player p = new Player();

            p.id = id;
            p.name = GetPlayerName(id);
            p.score = GetPlayerScore(id);

            return p;
        }

        public static void AddPlayer(string name)
        {
            try
            {
                Connect();
                string query = "INSERT INTO `trivia`.`players` (`PlayerName`) VALUES ('" + name + "');";
                cmd = new MySqlCommand(query, conn);

                reader = cmd.ExecuteReader();
            }
            catch (Exception ex) { }

            Disconnect();

        }

        public static int GetPlayerCount()
        {
            int count = 0;
            try
            {
                Connect();
                string query = "SELECT COUNT(*) FROM `trivia`.`players`;";
                cmd = new MySqlCommand(query, conn);

                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    count = reader.GetInt32(0);
                }
            }
            catch (Exception ex) { }

            Disconnect();
            return count;
        }

        public static void DeleteAllPlayersData() 
        {
            try
            {
                Connect();
                string query = "DELETE FROM `trivia`.`players`;";
                cmd = new MySqlCommand(query, conn);

                reader = cmd.ExecuteReader();
            }
            catch (Exception ex) { }

            Disconnect();
        }

        public static int GetPlayerScore(int id)
        {
            int score = -1;
            try
            {
                Connect();
                string query = "SELECT `PlayerScore` From `trivia`.`players` WHERE PlayerId = " + id;
                cmd = new MySqlCommand(query, conn);

                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    score = reader.GetInt32(0);
                }
            }
            catch (Exception ex) { }

            Disconnect();
            return score;
        }

        public static int GetPlayerStatus(string name)
        {
            int Status = 0;
            try
            {
                Connect();
                string query = "SELECT `PlayerTotalTime` From `trivia`.`players` WHERE PlayerName = " + name;
                cmd = new MySqlCommand(query, conn);

                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    Status = reader.GetInt32(0);
                }
            }
            catch (Exception ex) { }

            Disconnect();
            return Status;
        }

        public static int GetPlayerStatusSum()
        {
            int count = 0;
            try
            {
                Connect();
                string query = "SELECT SUM(PlayerFinished) FROM `trivia`.`players`;";
                cmd = new MySqlCommand(query, conn);

                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    count = reader.GetInt32(0);
                }
            }
            catch (Exception ex) { }

            Disconnect();
            return count;
        }

        public static string GetPlayerName(int id)
        {
            string name = string.Empty;
            try
            {
                Connect();
                string query = "SELECT PlayerName From trivia.players WHERE PlayerId = " + id;
                cmd = new MySqlCommand(query, conn);

                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    name = reader.GetString(0);
                }
            }
            catch (Exception ex) { }

            Disconnect();
            return name;
        }

        public static void AddScore(int id)
        {
            int score = GetPlayerScore(id);

            if (score == -1)
            {
                return;
            }

            score++;

            try
            {
                Connect();
                string query = "INSERT INTO `PlayerScore` FROM `trivia`.`players` WHERE PlayerId = " + id + " VALUES (" + score + ");";
                cmd = new MySqlCommand(query, conn);

                reader = cmd.ExecuteReader();
            }
            catch (Exception ex) { }

            Disconnect();
        }

        public static void Connect()
        {
            try
            {
                conn = new MySqlConnection(CON_STR);
                conn.Open();
                Console.WriteLine(conn.State);
            }
            catch 
            { 
                conn.Close();
            }
        }

        public static void Disconnect()
        {
            conn.Close();
        }

        

    }
}
