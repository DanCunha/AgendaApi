
using AgendaAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace AgendaAPI.Context
{
    public class AgendaContext : DbContext
    {
        public AgendaContext(DbContextOptions<AgendaContext> options) : base(options)
        {

        }

        public DbSet<Contato> Contatos{ get; set; }
    }
}