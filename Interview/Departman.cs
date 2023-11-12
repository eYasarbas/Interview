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


    public void FindEmployeesInSameHouseAndRank(List<Departman> departments, List<Calisan> employees)
    {
        var groupedDepartments = departments.GroupBy(d => d._kademe);

        foreach (var departmentGroup in groupedDepartments)
        {
            var currentDepartmentList = departmentGroup.ToList();
            var matchedEmployees = employees
                .Join(currentDepartmentList, e => e._departmanId, d => d._depertmantId, (e, d) =>
                    new { EmployeeId = e._userId, HouseId = e._evId, DepartmanKademe = d._kademe });
            var groupedHouses = matchedEmployees.GroupBy(e => e.HouseId);
            foreach (var houseGroup in groupedHouses)
            {
                if (houseGroup.Count() > 1)
                {
                    foreach (var employee in houseGroup)
                    {
                        Console.WriteLine($"Calışan Id: {employee.EmployeeId}, Ev Id: {employee.HouseId}, Departman Kademe: {employee.DepartmanKademe}");
                    }
                }
            }

        }
    }

}


