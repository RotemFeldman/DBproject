namespace TriviaAPI
{
    [System.Serializable]
    public class Player
    {
        public int id { get; set; }
        public string name { get; set; }
        public int score { get; set; }
        public int finished { get; set; }

        public Player()
        {
            id = 0;
            name = string.Empty;
            score = 0;
            finished = 0;
        }

        public Player(int id, string name, int score, int finished)
        {
            this.id = id;
            this.name = name;
            this.score = score;
            this.finished = finished;
        }
    }
}
