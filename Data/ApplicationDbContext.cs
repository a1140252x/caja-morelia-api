using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Data;

public class ApplicationDbContext : DbContext {
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {}

    public DbSet<Cliente> Clientes { get; set; }
}
