namespace CodingPie.Models
{
    public class PieRepository : IPieRepository
    {
        static List<Pie> _pieList = new()
        {
            new Pie{Id = 1, Name = "Doughnut", Description = "Delicious for the body", IsAvailable = true, Price = 400},
            new Pie{Id = 2, Name = "Meat Pie", Description = "Healthy", IsAvailable = true, Price = 200},
        };
        public Pie AddPie(Pie pie)
        {
            _pieList.Add(pie);
            return pie;
        }
        

        public void DeletePie(Pie pie)
        {
            _pieList.Remove(pie);
        }

        public IEnumerable<Pie> GetAll()
        {
            
            return _pieList;
        }

        public Pie GetPie(int id)
        {
            var pie = _pieList.Find(x => x.Id == id);
            return pie;
        }

        public Pie UpdatePie(Pie pie)
        {
            var x = _pieList.Find(x => x.Id == pie.Id);
            x.Name = pie.Name;
            x.Price = pie.Price;
            x.Description = pie.Description;
            return x;
        }
    }
}
