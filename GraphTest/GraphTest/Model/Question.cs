namespace GraphTest.Model;

public class Question
{
    public string Text { get; set; }
    public List<Answer> Answers { get; set; }

    public Question(string text, List<Answer> answers)
    {
        Text = text;
        Answers = answers;
    }

    public Params GetAdditionalParams(int answerNumber)
    {
        var answer = Answers[answerNumber];
        return answer.AdditionalParams;
    }
}