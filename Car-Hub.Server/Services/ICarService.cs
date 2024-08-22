using Car_Hub.Server.Model;

namespace Car_Hub.Server.Services
{
    public interface ICarService
    {
        void CreateCarModel(CarDTO carModel);

        IEnumerable<CarDTO> GetAllCarModels();
    }
}
