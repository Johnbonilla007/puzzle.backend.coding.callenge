using Microsoft.AspNetCore.Mvc;
using puzzle.backend.coding.callenge.NETCore.ApplicationServices.BookingAppSerices.Dtos;
using puzzle.backend.coding.callenge.NETCore.ApplicationServices.ClientAppServices.Commands.CreateOrUpdateClientCommand;
using puzzle.backend.coding.callenge.NETCore.ApplicationServices.ClientAppServices.Commands.DeleteClientCommand;
using puzzle.backend.coding.callenge.NETCore.ApplicationServices.ClientAppServices.Dtos;
using puzzle.backend.coding.callenge.NETCore.ApplicationServices.ClientAppServices.Queries.GetClientQueries;
using puzzle.backend.coding.callenge.NETCore.ApplicationServices.Core;

namespace puzzle.backend.coding.callenge.NETCore.Controllers
{
    [ApiController]
    [Route("api/v2/clients")]
    public class ClientController : ControllerBase
    {
        private readonly IGetClientQueries _getClientQueries;
        private readonly ICreateOrUpdateClientCommand _createOrUpdateClientCommand;
        private readonly IDeleteClientCommand _deleteClientCommand;
        public ClientController(IGetClientQueries getClientQueries,
                                IDeleteClientCommand deleteClientCommand,
                                ICreateOrUpdateClientCommand createOrUpdateClientCommand)
        {
            _getClientQueries = getClientQueries;
            _deleteClientCommand = deleteClientCommand;
            _createOrUpdateClientCommand = createOrUpdateClientCommand;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllClientsListAsync()
        {
            List<ClientDto> clients = await _getClientQueries.GetAllClientListAsync();

            return Ok(clients);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetClientByIdAsync(int id)
        {
            ClientDto? client = await _getClientQueries.GetClientByIdAsync(id);

            if (client == null)
            {
                return NotFound();
            }

            return Ok(client);
        }

        [HttpPost]
        public async Task<ActionResult> CreateOrUpdateBookingCommand(CreateOrUpdateClientRquest createOrUpdateClientRquest)
        {
            Response response = await _createOrUpdateClientCommand.ExecuteAsync(createOrUpdateClientRquest);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUpdateBooking(int id)
        {
            Response? response = await _deleteClientCommand.ExecuteAsync(id);

            if (response == null)
            {
                return NotFound();
            }

            return Ok(response);
        }

    }
}
