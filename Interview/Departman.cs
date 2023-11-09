namespace Interview;

public class Departman
{
    public Departman()
    {
    }

    public Departman(int departmentId, string name, int? parentDepartmentId, int rank)
    {
        _depertmantId = departmentId;
        _name = name;
        _parentDepartmanId = parentDepartmentId;
        _kademe = rank;
    }

    public int _depertmantId { get; set; }
    public string _name { get; set; }
    public int? _parentDepartmanId { get; set; }
    public int _kademe { get; set; }
    public List<Calisan> Calisanlar { get; set; } = new();
    public List<Departman> AltDepartmanlar { get; set; } = new();

    public void PrintCalisanlarByKademeAndEvId(List<Departman> departmanlar, List<Calisan> kisiler)
    {
        var departmanlarByKademe = departmanlar.GroupBy(d => d._kademe).OrderBy(g => g.Key)
            .ToDictionary(g => g.Key, g => g.ToList());

        foreach (var grup in departmanlarByKademe)
        {
            Console.WriteLine($"Kademe {grup.Key}:");
            foreach (var departman in grup.Value)
            {
                var departmanCalisanlar = kisiler.Where(k => k._departmanId == departman._depertmantId).ToList();
                var ayniEvdeCalisanlar = departmanCalisanlar.GroupBy(c => c._evId);

                foreach (var g in ayniEvdeCalisanlar)
                {
                    foreach (var calisan in g)
                    {
                        Console.WriteLine(calisan._name + "  " + calisan._evId);
                    }
                }

                Console.WriteLine();
            }
        }
    }

    public List<Calisan> GetAyniEvdeCalisanlar(List<Calisan> calisanList)
    {
        var ayniEvdeCalisanlar = new List<Calisan>();

        var gruplar = calisanList.GroupBy(c => c._evId);

        foreach (var grup in gruplar)
        {
            if (grup.Count() > 1)
            {
                ayniEvdeCalisanlar.AddRange(grup);
            }
        }

        return ayniEvdeCalisanlar;
    }
    public List<Calisan> GetCalisanlarByDepartmanId(int departmanId, List<Departman> departmanlar, List<Calisan> kisiler)
    {
        var calisanlar = new List<Calisan>();

        var departman = departmanlar.FirstOrDefault(d => d._depertmantId == departmanId);

        if (departman != null)
        {
            var anaDepartmanCalisanlar = kisiler.Where(k => k._departmanId == departman._depertmantId).ToList();
            calisanlar.AddRange(anaDepartmanCalisanlar);

            var cocuklar = departmanlar.Where(d => d._parentDepartmanId == departmanId).ToList();

            foreach (var cocuk in cocuklar)
            {
                var cocukCalisanlar = kisiler.Where(k => k._departmanId == cocuk._depertmantId).ToList();

                calisanlar.AddRange(cocukCalisanlar);

                calisanlar.AddRange(GetCalisanlarByDepartmanId(cocuk._depertmantId, departmanlar, kisiler));
            }
        }


        return calisanlar;
    }

}

