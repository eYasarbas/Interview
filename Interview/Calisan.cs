namespace Interview
{
    public class Calisan
    {
        public Calisan(int userId, string name, int evId, int departmantId)
        {
            _userId = userId;
            _name = name;
            _evId = evId;
            _departmanId = departmantId;
        }

        public Calisan()
        {
        }

        public int _userId { get; set; }
        public string _name { get; set; }
        public int _evId { get; set; }
        public int _departmanId { get; set; }

    }
}
