// See https://aka.ms/new-console-template for more information

using System.Text;

//Цель селекции
const string result = "salavat";
//Количество элементов в каждой выборке из популяции (увеличивайте для более быстрого результата)
const int populationSize = 10;

var random = new Random();

// Скрещивание двух слов
string CrossOver(string parent1, string parent2)
{
    var builder = new StringBuilder();
    for(var i = 0; i < parent1.Length; i++)
    {
        var flag = random.Next(0, 2);
        builder = flag == 0 
            ? builder.Append(parent1[i])
            : builder.Append(parent2[i]);
    }

    return builder.ToString();
}

//Получение рандомной строки
string RandomString()
{
    var builder = new StringBuilder(7);
    var offset = 'a';
    const int lettersOffset = 26;

    for (var i = 0; i < 7; i++)
    {
        var letter = (char)random.Next(offset, offset + lettersOffset);
        builder.Append(letter);
    }

    return builder.ToString();
}

//Генерация новой популяции из случайных слов
List<string> GeneratePopulation(int count)
{
    var population = new List<string>();
    for (var i = 0; i < count; i++)
    {
        population.Add(RandomString());
    }

    return population;
}

//Генерация нового поплуяции путем скрещивания
List<string> GenerateNextPopulation(List<string> parents)
{
    var newPopulation = new List<string>();
    var newParents = GeneratePopulation(populationSize);
    
    parents.ForEach(x =>
    {
        newParents.ForEach(y =>
        {
            newPopulation.Add(CrossOver(x, y));
        });
    });

    return newPopulation;
}

//Выбор родителей для нового поколения
List<string> SelectNewParents(List<string> population, int count)
{
    var childWithPenalty = new List<ChildWithPenalty>();
    var parents = new List<string>();

    childWithPenalty = population
        .Select(x => new ChildWithPenalty(x, CalculatePenalty(x)))
        .ToList();

    childWithPenalty.OrderBy(x => x.penalty).ToList().GetRange(0, count).ForEach(x =>
    {
        parents.Add(x.value);
    });
    
    return parents;
}

//Расчет штрафа к элементу популяции
//Проверяется наличие букв из цели селекции и совпадение этих букв по позициям
int CalculatePenalty(string name)
{
    var penalty = 0;
    result.ToList().ForEach(x =>
    {
        penalty += name.Contains(x) ? 0 : 1;
    });

    for (var i = 0; i < result.Length; i++)
    {
        penalty += name[i] == result[i] ? 0 : 1;
    }

    return penalty;
}

//Основной код
var population = GeneratePopulation(populationSize);
while (true)
{
    population = GenerateNextPopulation(population);
    population = SelectNewParents(population, populationSize);
    population.ForEach(x =>
    {
        if (x == result)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"{x}, ");
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write($"{x}, ");
        }
        
    });
    Console.WriteLine();
    //await Task.Delay(500);
    if (population.Contains(result))
    {
        Console.WriteLine($"!!!{population[population.IndexOf(result)].ToUpper()}!!!");
        break;
    }
}

//Элемент + его штраф
record ChildWithPenalty(string value, int penalty);