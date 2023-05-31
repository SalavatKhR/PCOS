namespace GraphTest.Model;

public class LuckBlock
{
    private LuckBlock(Dictionary<int, int> pointProbability, NextStep nextStep, List<string>? results)
    {
        PointProbability = pointProbability;
        NextStep = nextStep;
        Results = results;
    }

    private LuckBlock(Dictionary<int, int> pointProbability, NextStep nextStep, List<Question>? questions)
    {
        PointProbability = pointProbability;
        NextStep = nextStep;
        Questions = questions;
    }

    public Dictionary<int, int> PointProbability { get; set; }
    public NextStep NextStep { get; set; }
    public List<string>? Results { get; set; }
    public List<Question>? Questions { get; set; }

    public static LuckBlock QuestionLuckBlock(Dictionary<int, int> pointProbability, List<Question> questions) =>
        new(pointProbability, NextStep.NextQuestion, questions);
    
    public static LuckBlock TestResultLuckBlock(Dictionary<int, int> pointProbability, List<string> results) =>
        new(pointProbability, NextStep.TestResult, results);

    public string? GetResult(Params userParams)
    {
        if (Results == null || Results.Count < 2 || NextStep != NextStep.TestResult)
            return null;
        
        var random = new Random();
        var result = random.Next(1, 101);

        return result > PointProbability[userParams.GetPoints()]
            ? Results[0]
            : Results[1];
    }
    
    public Question? GetQuestion(Params userParams)
    {
        if (Questions == null || Questions.Count < 2 || NextStep != NextStep.NextQuestion)
            return null;
        
        var random = new Random();
        var result = random.Next(1, 101);

        return result > PointProbability[userParams.GetPoints()]
            ? Questions[0]
            : Questions[1];
    }
}