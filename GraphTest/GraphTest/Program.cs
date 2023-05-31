// See https://aka.ms/new-console-template for more information

using GraphTest.Model;
using static System.Int32;

var question5 = new Question(
    @"А?",
    new List<Answer>
    {
        Answer.AnswerWithResult(
            "Согласовать с руководителем, куда можно вставить выполнение этой задачи исходя из моего рабочего графика",
            new Params(1, 1 , 0),
            "Конец"),
        Answer.AnswerWithResult(
            "Задержаться", 
            new Params(0, 0 , 0), 
            "Конец"),
        Answer.AnswerWithResult(
            "Уйти домой, т.к. рабочий день закончился", 
            new Params(0, 1 , 0), 
            "Конец")
    });

var question4 = new Question(
    @"Руководство утверждает, 
          что вы слишком медленно выполняете задачи",
    new List<Answer>
    {
        Answer.AnswerWithResult( 
            "Объяснить, почему так происходит, и попросить больше помощи \\ времени \\ обучения", 
            new Params(1, 1 , 1), 
            "Конец"),
        Answer.AnswerWithQuestion(
            "Пообещать работать над собой", 
            new Params(0, 0 , 0), 
            question5)
    });

var luckBlock1 = LuckBlock.QuestionLuckBlock(
    new Dictionary<int, int> { { 1, 20 }, { 3, 60 } },
    new List<Question> {question5, question4});

var question3 = new Question(
    @"Из-за того вы долго разбирались с задачей, 
          вы не успеваете выполнить ее в срок.",
    new List<Answer>
    {
        Answer.AnswerWithLuckBlock(
            "Постараюсь работать быстрее", 
            new Params(0, 0 , 0), 
            luckBlock1),
        Answer.AnswerWithLuckBlock(
            "Объясню ситуацию наставнику, мы вместе найдем решение", 
            new Params(1, 1 , 0), 
            luckBlock1)
    });

var luckBlock2 = LuckBlock.TestResultLuckBlock(
    new Dictionary<int, int> { { 4, 70 }, { 3, 520 } },  
    new List<string>{"Конец1", "Конец2"});


var question2 = new Question(
    @"Коллега\аналитик объяснил вам суть задачи, 
          но вы в чем-то с ним не согласны 
          (совместимость\ложность реализации и т.д.)",
    new List<Answer>
    {
        Answer.AnswerWithLuckBlock(
            "Согласиться и взять задачу в разработку", 
            new Params(1, 0 , 0), 
            luckBlock2),
        Answer.AnswerWithResult(
            "Выразить свое мнение", 
            new Params(1, 1 , 1), 
            "Конец")
    });

var question1 = new Question(
    @"Вам пришла задача от аналитика.
          Вы не уверены, что поняли ее правильно. Ваши действия?",
    new List<Answer>
    {
        Answer.AnswerWithQuestion("Обращусь к более опытному коллеге", new Params(1, 1 , 0), question2),
        Answer.AnswerWithQuestion("Пойду разбираться к аналитику", new Params(1, 1 , 1), question2),
        Answer.AnswerWithQuestion("Постараюсь разобраться самостоятельно", new Params(0, 0 , 1), question3)
    });



//Main
var currentQuestion = question1;
LuckBlock? currentLuckBlock;
var userParams = new Params(0, 0, 0);

var result = "";

while (string.IsNullOrEmpty(result))
{
    Console.WriteLine(currentQuestion.Text);
    currentQuestion.Answers.ForEach(x =>
    {
        Console.WriteLine($"{currentQuestion.Answers.IndexOf(x) + 1}. {x.Text}");
    });
    Console.WriteLine("Введите номер ответа:");
    TryParse(Console.ReadLine(), out var answerNumber);

    if (answerNumber > currentQuestion.Answers.Count)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Ага-ага. На дурочка чтоли поймать хотел? Иди давай отсюда");
        return;
    }

    var answer = currentQuestion.Answers[answerNumber-1];
    
    userParams.Add(currentQuestion.GetAdditionalParams(answerNumber-1));
    
    switch (answer.NextStep)
    {
        case NextStep.NextQuestion:
        {
            currentQuestion = answer.Question;
            break;
        }
        case NextStep.TestResult:
        {
            result = answer.Result;
            break;
        }
        case NextStep.LuckBlock:
        {
            currentLuckBlock = answer.LuckBlock;
            if (currentLuckBlock.NextStep == NextStep.NextQuestion)
                currentQuestion = currentLuckBlock.GetQuestion(userParams);
            else
                result = currentLuckBlock.GetResult(userParams);
            break;
        }
    }
}

Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine(@$"Ваш результат: 
                        Коммуникативность {userParams.Communication}, 
                        Смелость {userParams.Courage}, 
                        Инициативность {userParams.Initiative}
                        Итого: {userParams.GetPoints()}");