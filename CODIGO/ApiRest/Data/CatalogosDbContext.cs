namespace ApiRest.Data;

using Microsoft.EntityFrameworkCore;
using ApiRest.Models;

    public class CatalogosDbContext : DbContext
    {
        public CatalogosDbContext (DbContextOptions<CatalogosDbContext> options)
            : base(options)
        {
        }

        public DbSet<Catalogos> Catalogos { get; set; } = default!;
    }
