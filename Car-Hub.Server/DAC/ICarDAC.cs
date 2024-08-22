using Car_Hub.Server.Model;

namespace Car_Hub.Server.DAC
{
    public interface ICarDAC
    {
        void CreateCarModel(CarDTO carModel);

        IEnumerable<CarDTO> GetAllCarModels();
    }
}
