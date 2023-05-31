using PCOS.Models;

namespace PCOS;

public static class Data
{
    static Data()
    {
        Students = new List<Student>();
    }
    public static List<Student> Students { get; set; }

    public static List<Topic> Topics => new()
    {
        new ("Австралия"),
        new ("Ирак"),
        new ("ЮАР"),
    };
    
    public static Test Test => new Test
        {
            Title = "Страны",
            Questions = new List<Question>
            {
                new Question
                {
                    Text = "Административная столица ЮАР?",
                    Topic = Topics[2],
                    Answers = new List<Answer>
                    {
                        new()
                        {
                            Number = 1,
                            Text = "Кейптаун",
                            IsCorrect = false
                        },
                        new()
                        {
                            Number = 2,
                            Text = "Претория",
                            IsCorrect = true
                        },
                        new()
                        {
                            Number = 3,
                            Text = "Порт-Элизабет",
                            IsCorrect = false
                        },
                        new()
                        {
                            Number = 4,
                            Text = "Айэм",
                            IsCorrect = false
                        }
                    }
                },
                new Question
                {
                    Text = "Столица Австралии?",
                    Topic = Topics[0],
                    Answers = new List<Answer>
                    {
                        new()
                        {
                            Number = 1,
                            Text = "Канберра",
                            IsCorrect = true
                        },
                        new()
                        {
                            Number = 2,
                            Text = "Сидней",
                            IsCorrect = false
                        },
                        new()
                        {
                            Number = 3,
                            Text = "Дарвин",
                            IsCorrect = false
                        },
                        new()
                        {
                            Number = 4,
                            Text = "Мельбурн",
                            IsCorrect = false
                        },
                    }
                },
                new Question
                {
                    Text = "Столица Ирака?",
                    Topic = Topics[1],
                    Answers = new List<Answer>
                    {
                        new()
                        {
                            Number = 1,
                            Text = "Кабул",
                            IsCorrect = false
                        },
                        new()
                        {
                            Number = 2,
                            Text = "Бейрут",
                            IsCorrect = false
                        },
                        new()
                        {
                            Number = 3,
                            Text = "Багдад",
                            IsCorrect = true
                        },
                        new()
                        {
                            Number = 4,
                            Text = "Тегерак",
                            IsCorrect = false
                        },
                    }
                },
                new Question
                {
                    Text = "На каком континенте находится Ирак?",
                    Topic = Topics[1],
                    Answers = new List<Answer>
                    {
                        new()
                        {
                            Number = 1,
                            Text = "Африка",
                            IsCorrect = false
                        },
                        new()
                        {
                            Number = 2,
                            Text = "Азия",
                            IsCorrect = true
                        },
                        new()
                        {
                            Number = 3,
                            Text = "Европа",
                            IsCorrect = false
                        },
                        new()
                        {
                            Number = 4,
                            Text = "Австралия",
                            IsCorrect = false
                        }
                    }
                },
                new Question
                {
                    Text = "На каком континенте находится Австралии?",
                    Topic = Topics[0],
                    Answers = new List<Answer>
                    {
                        new()
                        {
                            Number = 1,
                            Text = "Австралия",
                            IsCorrect = true
                        },
                        new()
                        {
                            Number = 2,
                            Text = "Азия",
                            IsCorrect = false
                        },
                        new()
                        {
                            Number = 3,
                            Text = "Европа",
                            IsCorrect = false
                        },
                        new()
                        {
                            Number = 4,
                            Text = "Северная Америка",
                            IsCorrect = false
                        },
                    }
                },
                new Question
                {
                    Text = "На каком континенте находится ЮАР?",
                    Topic = Topics[2],
                    Answers = new List<Answer>
                    {
                        new()
                        {
                            Number = 1,
                            Text = "Азия",
                            IsCorrect = false
                        },
                        new()
                        {
                            Number = 2,
                            Text = "Европа",
                            IsCorrect = false
                        },
                        new()
                        {
                            Number = 3,
                            Text = "Африка",
                            IsCorrect = true
                        },
                        new()
                        {
                            Number = 4,
                            Text = "Южная америка",
                            IsCorrect = false
                        },
                    }
                },
            }
        };
}