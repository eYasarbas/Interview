namespace Interview;

public class Ev
{
    public int _evId { get; set; }
    public string _name { get; set; }
    public List<Calisan> _calisan { get; set; } = new();
    public Ev()
    {
    }

    public Ev(int evId, string name, int parentEvId)
    {
        _evId = evId;
        _name = name;
    }
}