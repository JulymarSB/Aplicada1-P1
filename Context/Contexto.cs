using Microsoft.EntityFrameworkCore;

namespace Aplicada1P1.Context;

public class Contexto(DbContextOptions<Contexto> options) : DbContext(options)
{
    public DbSet<Autores> Autors
}