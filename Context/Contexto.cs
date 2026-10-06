using Microsoft.EntityFrameworkCore;
using Aplicada1P1.Models;
namespace Aplicada1P1.Context;

public class Contexto(DbContextOptions<Contexto> options) : DbContext(options)
{
    public virtual DbSet<Autores> Autores { get; set; }
}