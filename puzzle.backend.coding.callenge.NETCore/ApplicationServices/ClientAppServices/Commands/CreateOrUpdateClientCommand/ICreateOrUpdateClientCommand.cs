using puzzle.backend.coding.callenge.NETCore.ApplicationServices.ClientAppServices.Dtos;
using puzzle.backend.coding.callenge.NETCore.ApplicationServices.Core;

namespace puzzle.backend.coding.callenge.NETCore.ApplicationServices.ClientAppServices.Commands.CreateOrUpdateClientCommand
{
    public interface ICreateOrUpdateClientCommand
    {
        Task<Response> ExecuteAsync(CreateOrUpdateClientRquest createOrUpdateClientRquest);
    }
}
