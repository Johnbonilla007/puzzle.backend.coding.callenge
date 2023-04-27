using puzzle.backend.coding.callenge.NETCore.ApplicationServices.BookingAppSerices.Dtos;
using puzzle.backend.coding.callenge.NETCore.ApplicationServices.ClientAppServices.Dtos;

namespace puzzle.backend.coding.callenge.NETCore.ApplicationServices.ClientAppServices.Queries.GetClientQueries
{
    public interface IGetClientQueries
    {
        Task<List<ClientDto>> GetAllClientListAsync();
        Task<ClientDto?> GetClientByIdAsync(int id);
    }
}
