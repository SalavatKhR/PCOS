using Microsoft.AspNetCore.Mvc;
using PCOS.Models;


namespace PCOS.Controllers;

public class HomeController : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        return View(Data.Test);
    }

    [HttpPost]
    public IActionResult Index(string name, List<int> answers)
    {
        var student = Student.NewStudent(name);

        for (var i = 0; i < answers.Count; i++)
        {
            var question = Data.Test.Questions[i];
            var answer = question.Answers[answers[i] - 1];
            if (answer.IsCorrect)
            {
                student.TopicsPoints[question.Topic.Title] += 50;
            }
        }

        Data.Students.Add(student);
        
        return View(Data.Test);
    }
}