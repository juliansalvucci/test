using ContratoTestWebApi.Models;
using Microsoft.EntityFrameworkCore;


namespace ContratoTestWebApi.Contexts
{
    public class ApplicationDBContext: DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) { }

        public DbSet<Contrato> Contrato { get; set; }
        public DbSet<UnidadComercial> UnidadComercial { get; set; }
    }
}
