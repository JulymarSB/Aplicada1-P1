
using Aplicada1P1.Context;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Aplicada1.Core;

namespace Aplicada1P1.Models;



public class AutoresServices(IDbContextFactory<Contexto> contextFactory) : Aplicada1.Core.IService<Autores, int>
{
        public async Task<bool> Existe(int autorId)
        {
            await using var contexto = await contextFactory.CreateDbContextAsync();
            return await contexto.Autores.AnyAsync(a => a.IdAutor == autorId);
        }

        private async Task<bool> Insertar(Autores autor)
        {
            await using var contexto = await contextFactory.CreateDbContextAsync();
            contexto.Autores.Add(autor);
            return await contexto.SaveChangesAsync() > 0;
        }
        private async Task<bool> Modificar(Autores autor)
        {
            await using var contexto = await contextFactory.CreateDbContextAsync();
            contexto.Autores.Update(autor);
            return await contexto.SaveChangesAsync() > 0;
        }

        public async Task<bool> Guardar(Autores autor)
        {
            autor.IdAutor = autor.IdAutor;
            if (!await Existe(autor.IdAutor))
            {
                return await Insertar(autor);
            }
            else
            {
                return await Modificar(autor);
            }
        }
        public async Task<bool> Eliminar(int autorId)
        {
            await using var contexto = await contextFactory.CreateDbContextAsync();
            return await contexto.Autores
                .Where(p => p.IdAutor == autorId)
                .ExecuteDeleteAsync() > 0;
        }

        public async Task<Autores?> Buscar(int autorId)
        {
            await using var contexto = await contextFactory.CreateDbContextAsync();
            return await contexto.Autores.FirstOrDefaultAsync(a => a.IdAutor == autorId);
        }

        public async Task<List<Autores>> GetList(Expression<Func<Autores, bool>> criterio)
        {
            await using var contexto = await contextFactory.CreateDbContextAsync();
            return await contexto.Autores.Where(criterio).AsNoTracking().ToListAsync();
        }


}
