using System.Collections.Generic;
using System.Threading.Tasks;

namespace DiscordBot
{
    public class QuestionAndAnswer
    {
        public string question { get; set; }
        public string correct_answer { get; set; }
        public List<string> incorrect_answers { get; set; }

        public async static  Task<string> ReplaceHtmlChars(string question)
        {
            if (question.Contains("&#039"))
            {
                question = question.Replace("&#039", "'");
            }
            if (question.Contains("&quot;"))
            {
                question = question.Replace("&quot;", "\"");

            }

            return question;
        }
    }
}