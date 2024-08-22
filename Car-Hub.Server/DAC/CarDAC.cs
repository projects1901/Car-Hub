using Car_Hub.Server.Model;
using System.Data.SqlClient;

namespace Car_Hub.Server.DAC
{
    public class CarDAC: ICarDAC
    {
        private readonly string _connectionString;

        public CarDAC(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("CarDBConnection");
        }

        public void CreateCarModel(CarDTO carModel)
        {
            int carModelId = 0;
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string query = @"INSERT INTO CarModels (
	                                Brand
	                                ,Class
	                                ,ModelName
	                                ,ModelCode
	                                ,Description
	                                ,Features
	                                ,Price
	                                ,DateOfManufacturing
	                                ,IsActive
	                                ,SortOrder
	                                )
                                VALUES (
	                                @Brand
	                                ,@Class
	                                ,@ModelName
	                                ,@ModelCode
	                                ,@Description
	                                ,@Features
	                                ,@Price
	                                ,@DateOfManufacturing
	                                ,@Active
	                                ,@SortOrder
	                                )

                                SELECT CAST(SCOPE_IDENTITY() AS INT);";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Brand", carModel.Brand);
                cmd.Parameters.AddWithValue("@Class", carModel.Class);
                cmd.Parameters.AddWithValue("@ModelName", carModel.ModelName);
                cmd.Parameters.AddWithValue("@ModelCode", carModel.ModelCode);
                cmd.Parameters.AddWithValue("@Description", carModel.Description);
                cmd.Parameters.AddWithValue("@Features", carModel.Features);
                cmd.Parameters.AddWithValue("@Price", carModel.Price);
                cmd.Parameters.AddWithValue("@DateOfManufacturing", carModel.DateOfManufacturing);
                cmd.Parameters.AddWithValue("@Active", carModel.Active);
                cmd.Parameters.AddWithValue("@SortOrder", carModel.SortOrder);

                conn.Open();
                carModelId = (int)cmd.ExecuteScalar();
                conn.Close();
            }
            if (carModelId != 0 && carModel.ImageUrls.Any())
            {
                InsertAllImage(carModel.ImageUrls, carModelId);
            }
        }

        public IEnumerable<CarDTO> GetAllCarModels()
        {
            List<CarDTO> carModels = new List<CarDTO>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string query = @"SELECT * FROM CarModels ORDER BY DateOfManufacturing DESC, SortOrder ASC";
                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CarDTO carModel = new CarDTO
                    {
                        Id = Convert.ToInt32(reader["CarModelId"]),
                        Brand = reader["Brand"].ToString(),
                        Class = reader["Class"].ToString(),
                        ModelName = reader["ModelName"].ToString(),
                        ModelCode = reader["ModelCode"].ToString(),
                        Description = reader["Description"].ToString(),
                        Features = reader["Features"].ToString(),
                        Price = Convert.ToDecimal(reader["Price"]),
                        DateOfManufacturing = Convert.ToDateTime(reader["DateOfManufacturing"]),
                        Active = Convert.ToBoolean(reader["IsActive"]),
                        SortOrder = Convert.ToInt32(reader["SortOrder"]),
                        ImageUrls = GetImageUrls(Convert.ToInt32(reader["CarModelId"]))
                    };
                    carModels.Add(carModel);
                }
                conn.Close();
            }

            return carModels;
        }

        private void InsertAllImage(IList<string> imagesPath, int carId)
        {
            if(imagesPath.Any() == true)
            {
                foreach (string imagePath in imagesPath)
                {
                    ImageDTO imageDTO = new ImageDTO()
                    {
                        CarModelId = carId,
                        ImagePath = imagePath
                    };
                    InsertImage(imageDTO);
                }
            }

        }

        private void InsertImage(ImageDTO imageDTO)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string query = @"INSERT INTO Images
                             VALUES (@CarModelId, @ImagePath)";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@CarModelId", imageDTO.CarModelId);
                cmd.Parameters.AddWithValue("@ImagePath", imageDTO.ImagePath);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        private List<string> GetImageUrls(int carModelId)
        {
            List<string> imageUrls = new List<string>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string query = @"SELECT ImagePath FROM Images WHERE CarModelId = @CarModelId";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@CarModelId", carModelId);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    imageUrls.Add(reader["ImagePath"].ToString());
                }
                conn.Close();
            }

            return imageUrls;
        }

    }
}
