namespace Schedule;

public static class Data
{
    public static List<string> Groups => new() { "11-010", "11-011", "11-012" };
    public static List<string> Lessons => new() { "ПЦОС", "ОПИПК"};
    public static List<int> Times => new() { 1, 2, 3, 4, 5, 6};
    
    public static Dictionary<ScheduleRecord, bool> ScheduleTemplate => new Dictionary<ScheduleRecord, bool>
    {
        {new (Groups[0], Lessons[0], 0), false},
        {new (Groups[0], Lessons[0], 0), false},
        {new (Groups[0], Lessons[1], 0), false},
        {new (Groups[0], Lessons[1], 0), false},
        {new (Groups[1], Lessons[0], 0), false},
        {new (Groups[1], Lessons[0], 0), false},
        {new (Groups[1], Lessons[1], 0), false},
        {new (Groups[1], Lessons[1], 0), false},
        {new (Groups[2], Lessons[0], 0), false},
        {new (Groups[2], Lessons[0], 0), false},
        {new (Groups[2], Lessons[1], 0), false},
        {new (Groups[2], Lessons[1], 0), false},
    };
}