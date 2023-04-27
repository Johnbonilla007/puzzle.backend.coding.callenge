using Microsoft.EntityFrameworkCore;
using puzzle.backend.coding.callenge.NETCore.ApplicationServices.Core;
using puzzle.backend.coding.callenge.NETCore.Infraestructure.DataContext;

namespace puzzle.backend.coding.callenge.NETCore.ApplicationServices.ClientAppServices.Commands.DeleteClientCommand
{
    public class DeleteClientCommand : BaseAppService, IDeleteClientCommand
    {
        public DeleteClientCommand(MyDbContext context) : base(context)
        {
        }

        public async Task<Response?> ExecuteAsync(int id)
        {
            var client = await _context.Clients.FindAsync(id);
            if (client == null)
            {
                return null;
            }

            _context.Clients.Remove(client);
            _context.Entry(client).State = EntityState.Deleted;

            await _context.SaveChangesAsync();

            return new Response { Success = true };
        }
    }
}
