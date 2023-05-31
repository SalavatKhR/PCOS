namespace GraphTest.Model;

public class Params
{
    public int Communication { get; set; }
    public int Courage { get; set; }
    public int Initiative { get; set; }

    public Params(int communication, int courage, int initiative)
    {
        Communication = communication;
        Courage = courage;
        Initiative = initiative;
    }
    
    public void Add(Params add)
    {
        Communication += add.Communication;
        Courage += add.Courage;
        Initiative += add.Initiative;
    }

    public int GetPoints() => Communication + Courage + Initiative;
}