namespace GraphTest.Model;

public class Answer
{
    private Answer(string text, NextStep nextStep, string? result, Params additionalParams)
    {
        Text = text;
        NextStep = nextStep;
        Result = result;
        AdditionalParams = additionalParams;
    }

    private Answer(string text, NextStep nextStep, Question? question, Params additionalParams)
    {
        Text = text;
        NextStep = nextStep;
        Question = question;
        AdditionalParams = additionalParams;
    }
    
    private Answer(string text, NextStep nextStep, LuckBlock luckBlock, Params additionalParams)
    {
        Text = text;
        NextStep = nextStep;
        LuckBlock = luckBlock;
        AdditionalParams = additionalParams;
    }
    
    public string Text { get; set; }
    public NextStep NextStep { get; set; }
    public Params AdditionalParams { get; set; }
    public string? Result { get; set; }
    public Question? Question { get; set; }
    public LuckBlock? LuckBlock { get; set; }

    public static Answer AnswerWithResult(string text, Params additionalParams, string result) 
        => new(text,NextStep.TestResult, result, additionalParams);
    
    public static Answer AnswerWithQuestion(string text, Params additionalParams, Question question) 
        => new(text, NextStep.NextQuestion, question, additionalParams);
    
    public static Answer AnswerWithLuckBlock(string text, Params additionalParams, LuckBlock luckBlock) 
        => new(text, NextStep.LuckBlock, luckBlock, additionalParams);
}