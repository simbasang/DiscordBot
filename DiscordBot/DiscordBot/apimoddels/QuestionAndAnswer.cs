using System.Collections.Generic;

namespace DiscordBot
{
    public class QuestionAndAnswer
    {
        public string question { get; set; }
        public string correct_answer { get; set; }
        public List<string> incorrect_answers { get; set; }
    }
}