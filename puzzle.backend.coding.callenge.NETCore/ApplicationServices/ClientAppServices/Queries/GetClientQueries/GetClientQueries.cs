using Microsoft.EntityFrameworkCore;
using puzzle.backend.coding.callenge.NETCore.ApplicationServices.BookingAppSerices.Dtos;
using puzzle.backend.coding.callenge.NETCore.ApplicationServices.ClientAppServices.Dtos;
using puzzle.backend.coding.callenge.NETCore.ApplicationServices.Core;
using puzzle.backend.coding.callenge.NETCore.Domain.Aggregates.BookinAgg;
using puzzle.backend.coding.callenge.NETCore.Domain.Aggregates.ClientAgg;
using puzzle.backend.coding.callenge.NETCore.Infraestructure.DataContext;

namespace puzzle.backend.coding.callenge.NETCore.ApplicationServices.ClientAppServices.Queries.GetClientQueries
{
    public class GetClientQueries : BaseAppService, IGetClientQueries
    {
        public GetClientQueries(MyDbContext context) : base(context)
        {
        }

        public async Task<List<ClientDto>> GetAllClientListAsync()
        {
            List<ClientDto> clientListDtos = new List<ClientDto>();
            List<Client> clients = await _context.Clients.ToListAsync();

            if (clients != null && clients.Any())
            {
                clientListDtos = clients.Select(c => new ClientDto
                {
                    ClientId = c.ClientId,
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                    Email = c.Email,
                    Phone = c.Phone,
                    DateOfBirth = c.DateOfBirth
                }).ToList();
            }

            return clientListDtos;
        }

        public async Task<ClientDto?> GetClientByIdAsync(int id)
        {
            if (id == 0) return null;

            Client? client = await _context.Clients.FirstOrDefaultAsync(r => r.ClientId == id);

            if (client == null) return null;

            return new ClientDto
            {
                ClientId = client.ClientId,
                FirstName = client.FirstName,
                LastName = client.LastName,
                Email = client.Email,
                Phone = client.Phone,
                DateOfBirth = client.DateOfBirth,

            };
        }
    }
}
