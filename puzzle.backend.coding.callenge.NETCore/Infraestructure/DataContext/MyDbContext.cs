using Microsoft.EntityFrameworkCore;
using puzzle.backend.coding.callenge.NETCore.Domain.Aggregates.BookinAgg;
using puzzle.backend.coding.callenge.NETCore.Domain.Aggregates.ClientAgg;
using puzzle.backend.coding.callenge.NETCore.Domain.Aggregates.EventAgg;
using puzzle.backend.coding.callenge.NETCore.Domain.Aggregates.FurnitureAgg;
using puzzle.backend.coding.callenge.NETCore.Domain.Aggregates.StatusAgg;
using System.Xml;

namespace puzzle.backend.coding.callenge.NETCore.Infraestructure.DataContext
{
    public class MyDbContext : DbContext
    {
        public DbSet<Client> Client { get; set; }
        public DbSet<Event> Event { get; set; }
        public DbSet<Furniture> Furniture { get; set; }
        public DbSet<Booking> Booking { get; set; }
        public DbSet<Status> Status { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=tcp:puzzle-callenge-server.database.windows.net,1433;Initial Catalog=puzzle.backend.coding.callenge;Persist Security Info=False;User ID=root_database;Password=Hola1234;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }
    }
}
