using CodingPie.ViewModels;
using System.Xml.Linq;

namespace CodingPie.Models
{
    public class PieService : IPieService
    {
        private readonly IPieRepository _repository;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public PieService(IPieRepository repository, IWebHostEnvironment webHostEnvironment)
        {
            _repository = repository;
            _webHostEnvironment = webHostEnvironment;
        }
        public Pie AddPie(CreatePieViewModel model)
        {
            string fileName = "";
            if(model.Photo != null)
            {
                string uploadFolderPath = Path.Combine(_webHostEnvironment.WebRootPath, "images");
                fileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                string pictureFullPath = Path.Combine(uploadFolderPath, fileName);
                model.Photo.CopyTo(new FileStream(pictureFullPath, FileMode.Create));
            }
            
            var pie = new Pie();
            pie.Id = 3;
            pie.Name = model.Name;
            pie.Price = model.Price;
            pie.Description = model.Description;
            pie.IsAvailable = true;
            pie.PiePicturePath = fileName;
            _repository.AddPie(pie);
            return pie;
        }



        public void DeletePie(int id)
        {
            var pie = _repository.GetPie(id);
            _repository.DeletePie(pie);
        }

        public IEnumerable<Pie> GetAllPies()
        {
           return _repository.GetAll();
        }

        public Pie GetPie(int id)
        {
            var pie = _repository.GetPie(id);
            return pie;
        }

        public Pie UpdatePie(Pie pie)
        {
            //var pi = _repository.GetPie(pie.Id);
            _repository.UpdatePie(pie);
            return pie;
        }
    }
}
