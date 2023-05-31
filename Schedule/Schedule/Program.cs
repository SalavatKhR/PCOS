var schedule = Schedule.Schedule.CreateRandom();
schedule.SetPenalties();
var penalty = schedule.CountPenalties();

var iteration = 0;

while(penalty != 0)
{
    iteration++;
    
    schedule = schedule.GenerateNext();
    schedule.SetPenalties();
    penalty = schedule.CountPenalties();
}

schedule.Print();
Console.WriteLine($"Кол-во итераций {iteration}");
