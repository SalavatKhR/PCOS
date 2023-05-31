namespace PCOS.Models;

public class Question
{
    public string Text { get; set; }
    public Topic Topic { get; set; }
    public List<Answer> Answers { get; set; }
}