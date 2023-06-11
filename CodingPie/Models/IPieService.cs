using CodingPie.ViewModels;

namespace CodingPie.Models
{
    public interface IPieService
    {
        IEnumerable<Pie> GetAllPies();
        Pie AddPie(CreatePieViewModel model);
        Pie GetPie(int id);
        Pie UpdatePie(Pie pie);
        void DeletePie(int id);
    }
}
