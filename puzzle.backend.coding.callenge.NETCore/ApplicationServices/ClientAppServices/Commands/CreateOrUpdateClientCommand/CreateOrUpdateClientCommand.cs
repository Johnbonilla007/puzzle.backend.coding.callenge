using Microsoft.EntityFrameworkCore;
using puzzle.backend.coding.callenge.NETCore.ApplicationServices.ClientAppServices.Dtos;
using puzzle.backend.coding.callenge.NETCore.ApplicationServices.Core;
using puzzle.backend.coding.callenge.NETCore.Domain.Aggregates.ClientAgg;
using puzzle.backend.coding.callenge.NETCore.Infraestructure.DataContext;

namespace puzzle.backend.coding.callenge.NETCore.ApplicationServices.ClientAppServices.Commands.CreateOrUpdateClientCommand
{
    public class CreateOrUpdateClientCommand : BaseAppService, ICreateOrUpdateClientCommand
    {
        public CreateOrUpdateClientCommand(MyDbContext context) : base(context)
        {
        }

        public async Task<Response> ExecuteAsync(CreateOrUpdateClientRquest createOrUpdateClientRquest)
        {
            if (createOrUpdateClientRquest == null) return new Response { Success = false };

            Client? client = await _context.Clients.FirstOrDefaultAsync(x => x.ClientId == createOrUpdateClientRquest.ClientId);

            if (client == null)
            {
                client = new Client
                {
                    FirstName = createOrUpdateClientRquest.FirstName,
                    LastName = createOrUpdateClientRquest.LastName,
                    Email = createOrUpdateClientRquest.Email,
                    Phone = createOrUpdateClientRquest.Phone,
                    DateOfBirth = createOrUpdateClientRquest.DateOfBirth,
                };

                _context.Entry(client).State = EntityState.Added;
                await _context.Clients.AddAsync(client);

            }
            else
            {
                client.FirstName = createOrUpdateClientRquest.FirstName;
                client.LastName = createOrUpdateClientRquest.LastName;
                client.Email = createOrUpdateClientRquest.Email;
                client.Phone = createOrUpdateClientRquest.Phone;
                client.DateOfBirth = createOrUpdateClientRquest.DateOfBirth;
                _context.Entry(client).State = EntityState.Modified;
            }

            await _context.SaveChangesAsync();

            return new Response { Success = true };
        }
    }
}
