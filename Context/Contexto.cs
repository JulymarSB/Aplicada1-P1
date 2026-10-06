using Aplicada1P1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
namespace Aplicada1P1.Context;

public class Contexto : DbContext
{ 
    public Contexto(DbContextOptions<Contexto> options) : base(options) { }
    public virtual DbSet<Autores> Autores { get; set; }
}