using puzzle.backend.coding.callenge.NETCore.ApplicationServices.Core;

namespace puzzle.backend.coding.callenge.NETCore.ApplicationServices.ClientAppServices.Commands.DeleteClientCommand
{
    public interface IDeleteClientCommand
    {
        Task<Response?> ExecuteAsync(int id);
    }
}
