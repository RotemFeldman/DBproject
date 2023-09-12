namespace TriviaAPI
{
    [System.Serializable]
    public class Question
    {
        public string text { get; set; }
        public string ans1 { get; set; }
        public string ans2 { get; set; }
        public string ans3 { get; set; }
        public string ans4 { get; set; }

        public Question(string text, string ans1, string ans2, string ans3, string ans4)
        {
            this.text = text;
            this.ans1 = ans1;
            this.ans2 = ans2;
            this.ans3 = ans3;
            this.ans4 = ans4;
        }

        public Question()
        {
            this.text = string.Empty;
            this.ans1 = string.Empty;
            this.ans2 = string.Empty;
            this.ans3 = string.Empty;
            this.ans4 = string.Empty;
        }
    }
}
