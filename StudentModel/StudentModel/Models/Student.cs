namespace PCOS.Models;

public class Student
{
    private Student(string name, Dictionary<string, int> topicsPoints)
    {
        Name = name;
        TopicsPoints = topicsPoints;
    }
    
    public string Name { get; set; }
    public Dictionary<string, int> TopicsPoints { get; set; }

    public static Student NewStudent(string name)
    {
        var topicsPoints = new Dictionary<string, int>();
        Data.Topics.ForEach(x =>
        {
            topicsPoints.Add(x.Title, 0);
        });

        return new Student(name, topicsPoints);
    }
}