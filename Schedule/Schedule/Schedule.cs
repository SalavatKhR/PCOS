namespace Schedule;

public class Schedule
{
    private Schedule(Dictionary<ScheduleRecord, bool> schedule)
    {
        Records = schedule;
        OverlaysIndexes = new Dictionary<int, int>();
    }

    public Dictionary<ScheduleRecord, bool> Records { get; set; }
    public Dictionary<int, int> OverlaysIndexes { get; set; }

    public static Schedule CreateRandom()
    {
        var random = new Random();
        var schedule = Data.ScheduleTemplate;
        
        foreach (var record in schedule)
        {
            record.Key.Time = Data.Times[random.Next(0, 6)];
        }

        return new Schedule(schedule);
    }

    public static Schedule CreateEmpty() => new Schedule(Data.ScheduleTemplate);

    public void SetPenalties()
    {
        for (var i = 0; i < Records.Count; i++)
        {
            for (var j = 0; j < Records.Count; j++)
            {
                if (i == j) continue;
                var key = Records.ElementAt(i).Key;
                if (CheckOverlay(Records.ElementAt(i).Key, Records.ElementAt(j).Key))
                {
                    Records[key] = true;
                    if (!OverlaysIndexes.TryAdd(i, j))
                        OverlaysIndexes[i] = j;
                }
            }
        }
    }

    public int CountPenalties()
    {
        var count = 0;
        foreach (var record in Records)
        {
            count += record.Value ? 1 : 0;
        }

        return count;
    }


    public Schedule GenerateNext()
    {
        var randomSchedule = CreateRandom();
        var newSchedule = new Schedule(new Dictionary<ScheduleRecord, bool>());

        for (var i = 0; i < Records.Count; i++)
        {
            var record = Records.ElementAt(i);
            if (record.Value)
            {
                var newRecord = randomSchedule.Records.ElementAt(i);
                Records[Records.ElementAt(OverlaysIndexes[i]).Key] = false;
                newSchedule.Records.Add(newRecord.Key, newRecord.Value);
            }
            else
            {
                newSchedule.Records.Add(record.Key, record.Value);
            }
        }

        return newSchedule;
    }

    private bool CheckOverlay(ScheduleRecord record1, ScheduleRecord record2)
    {
        if (record1.Group == record2.Group && record1.Time == record2.Time)
            return true;
        if (record1.Lesson == record2.Lesson && record1.Time == record2.Time)
            return true;
        return false;
    }

    public void Print()
    {
        foreach (var record in Records.OrderBy(x=> x.Key.Time))
        {
            Console.WriteLine($"{record.Key.Time}. {record.Key.Group}: {record.Key.Lesson}");
        }
    }
}