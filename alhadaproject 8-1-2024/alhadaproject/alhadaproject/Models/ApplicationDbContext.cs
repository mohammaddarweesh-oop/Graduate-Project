using alhadaproject.Models;
using Microsoft.EntityFrameworkCore;

namespace alhadaProject.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Land> Lands { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<ClientDetail> ClientDetails { get; set; }
        public DbSet<StateImage> StateImages { get; set; }
        public DbSet<Inbox> Inboxes { get; set; }
        

    }
}
