using Interview;

public class Program
{
    public static void Main(string[] args)
    {
        var evler = new List<Ev>
        {
            new() { _evId = 1, _name = "Ev1"},
            new() { _evId = 2, _name = "Ev2"},
            new() { _evId = 3, _name = "Ev3"},
            new() { _evId = 4, _name = "Ev4"},
            new() { _evId = 5, _name = "Ev5"},
            new() { _evId = 6, _name = "Ev6"}
        };

        var depertmantlar = new List<Departman>
        {
            new() { _depertmantId = 1, _name = "Depertmant1", _parentDepartmanId = null, _kademe = 1 },
            new() { _depertmantId = 2, _name = "Depertmant2", _parentDepartmanId = 1, _kademe = 2 },
            new() { _depertmantId = 3, _name = "Depertmant3", _parentDepartmanId = 1, _kademe = 2 },
            new() { _depertmantId = 4, _name = "Depertmant4", _parentDepartmanId = 2, _kademe = 3 },
            new() { _depertmantId = 5, _name = "Depertmant5", _parentDepartmanId = 2, _kademe = 3 },
            new() { _depertmantId = 6, _name = "Depertmant6", _parentDepartmanId = 3, _kademe = 3 },
            new() { _depertmantId = 7, _name = "Depertmant7", _parentDepartmanId = 5, _kademe = 4 },
            new() { _depertmantId = 8, _name = "Depertmant8", _parentDepartmanId = 5, _kademe = 4 }
        };

        var kisiler = new List<Calisan>
        {
            new() { _userId = 1, _name = "Kisi1", _departmanId = 7, _evId = 1 },
            new() { _userId = 2, _name = "Kisi2", _departmanId = 4, _evId = 2 },
            new() { _userId = 3, _name = "Kisi3", _departmanId = 3, _evId = 3 },
            new() { _userId = 4, _name = "Kisi4", _departmanId = 6, _evId = 1 },
            new() { _userId = 5, _name = "Kisi5", _departmanId = 1, _evId = 4 },
            new() { _userId = 6, _name = "Kisi6", _departmanId = 2, _evId = 5 },
            new() { _userId = 7, _name = "Kisi7", _departmanId = 3, _evId = 2 },
            new() { _userId = 8, _name = "Kisi8", _departmanId = 4, _evId = 1 },
            new() { _userId = 9, _name = "Kisi9", _departmanId = 5, _evId = 3 },
            new() { _userId = 10, _name = "Kisi10", _departmanId = 2, _evId = 6 },
            new() { _userId = 11, _name = "Kisi11", _departmanId = 8, _evId = 6 },


        };
        var listEv = new Ev();
        var listDepartman = new Departman();
        var listKisiler = new Calisan();


        Console.WriteLine("Departman2 ye bağlı tüm çalışanların listesi: \n ");
        var sonuc = listDepartman.GetCalisanlarByDepartmanId(2, depertmantlar, kisiler);
        foreach (var calisan in sonuc)
        {
            Console.WriteLine($"{calisan._name} departmanId:  {calisan._departmanId}");
        }




        Console.WriteLine("\nAynı kademeye sahip çalışanlar listesi\n");
        listDepartman.FindEmployeesInSameHouseAndRank(depertmantlar, kisiler);

    }
}