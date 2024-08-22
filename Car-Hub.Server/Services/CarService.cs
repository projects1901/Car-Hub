using Car_Hub.Server.DAC;
using Car_Hub.Server.Model;

namespace Car_Hub.Server.Services
{
    public class CarService: ICarService
    {
        private readonly ICarDAC _carDAC;

        public CarService(ICarDAC carDAC)
        {
            _carDAC = carDAC;
        }

        public void CreateCarModel(CarDTO carDTO)
        {
            this._carDAC.CreateCarModel(carDTO);
        }

        public IEnumerable<CarDTO> GetAllCarModels()
        {
            return this._carDAC.GetAllCarModels();
        }
    }
}
