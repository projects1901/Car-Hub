namespace Car_Hub.Server.Model
{
    public class CarDTO
    {
        public int Id { get; set; }
        public string Brand { get; set; } // Audi, Jaguar, Land Rover, Renault
        public string Class { get; set; } // A-Class, B-Class, C-Class
        public string ModelName { get; set; }
        public string ModelCode { get; set; } 
        public string Description { get; set; }
        public string Features { get; set; }
        public decimal Price { get; set; }
        public DateTime DateOfManufacturing { get; set; }
        public bool Active { get; set; }
        public int SortOrder { get; set; }
        public List<string> ImageUrls { get; set; }
    }
}
