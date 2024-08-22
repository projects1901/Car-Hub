using Car_Hub.Server.Model;

namespace Car_Hub.Server.DAC
{
    public interface IUserDAC
    {
        Task<UserDTO> RegisterUserAsync(RegisterDTO registerDto);
        Task<UserDTO> ValidateUserAsync(string username, string password);
    }
}
