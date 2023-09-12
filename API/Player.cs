namespace TriviaAPI
{
    [System.Serializable]
    public class Player
    {
        public int id { get; set; }
        public string name { get; set; }
        public int score { get; set; }
        public float time { get; set; }

        public Player()
        {
            id = 0;
            name = string.Empty;
            score = 0;
            time = 0;
        }

        public Player(int id, string name, int score, float time)
        {
            this.id = id;
            this.name = name;
            this.score = score;
            this.time = time;
        }
    }
}
