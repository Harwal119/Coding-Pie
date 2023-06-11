namespace CodingPie.Models
{
    public interface IPieRepository
    {
        Pie AddPie(Pie pie);
        Pie UpdatePie(Pie pie);
        Pie GetPie(int id);
        IEnumerable<Pie> GetAll();
        void DeletePie(Pie pie);
    }
}
