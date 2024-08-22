using Car_Hub.Server.Model;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;

namespace Car_Hub.Server.DAC
{
    public class UserDAC : IUserDAC
    {
        private readonly string _connectionString;
        public UserDAC(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("CarDBConnection");
        }

        public async Task<UserDTO> RegisterUserAsync(RegisterDTO registerDto)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                // Hash the password
                var passwordHash = HashPassword(registerDto.Password);

                var command = new SqlCommand("INSERT INTO Users (FullName, Username, PasswordHash) OUTPUT INSERTED.Id, INSERTED.FullName, INSERTED.Username VALUES (@FullName, @Username, @PasswordHash)", connection);
                command.Parameters.AddWithValue("@FullName", registerDto.FullName);
                command.Parameters.AddWithValue("@Username", registerDto.Username);
                command.Parameters.AddWithValue("@PasswordHash", passwordHash);

                var reader = await command.ExecuteReaderAsync();
                if (await reader.ReadAsync())
                {
                    return new UserDTO
                    {
                        Id = reader.GetInt32(0),
                        FullName = reader.GetString(1),
                        Username = reader.GetString(2)
                    };
                }
            }

            return null; // Registration failed
        }

        public async Task<UserDTO> ValidateUserAsync(string username, string password)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                var command = new SqlCommand("SELECT Id, FullName, Username, PasswordHash FROM Users WHERE Username = @Username", connection);
                command.Parameters.AddWithValue("@Username", username);

                var reader = await command.ExecuteReaderAsync();
                if (await reader.ReadAsync())
                {
                    var storedPasswordHash = reader.GetString(3);
                    if (VerifyPassword(password, storedPasswordHash))
                    {
                        return new UserDTO
                        {
                            Id = reader.GetInt32(0),
                            FullName = reader.GetString(1),
                            Username = reader.GetString(2)
                        };
                    }
                }
            }

            return null; // Invalid credentials
        }

        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var bytes = Encoding.UTF8.GetBytes(password);
                var hash = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }

        private bool VerifyPassword(string password, string storedHash)
        {
            var hashOfInput = HashPassword(password);
            return hashOfInput == storedHash;
        }
    }
}
