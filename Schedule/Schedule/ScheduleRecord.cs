namespace Schedule;

public class ScheduleRecord
{
    public ScheduleRecord(string group, string lesson, int time)
    {
        Group = group;
        Lesson = lesson;
        Time = time;
    }
    
    public string Group {get; set; }
    public string Lesson {get; set; }
    public int Time {get; set; }
}