using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using data.Context;
using domain.Entities;
using domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace data.Repository
{
  public class BaseRepository<Table> : IRepository<Table> where Table : BaseEntity
  {
    protected readonly MyContext _context;

    private DbSet<Table> _dataset;

    public BaseRepository(MyContext context)
    {
      _context = context;
      _dataset = _context.Set<Table>();
    }

    public async Task<bool> ExistAsync(Guid id)
    {
      return await _dataset.AnyAsync(x => x.Id.Equals(id));
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
      try
      {
        var result = await _dataset.SingleOrDefaultAsync(p => p.Id.Equals(id));
        if (result == null) return false;
        _dataset.Remove(result);
        await _context.SaveChangesAsync();
        return true;
      }
      catch (Exception ex)
      {
        throw new Exception("Erro ao deletar.", ex);
      }
    }

    public async Task<Table> InsertAsync(Table entity)
    {
      try
      {
        if (entity.Id == Guid.Empty)
        {
          entity.Id = Guid.NewGuid();
        }

        entity.CreatedAt = DateTime.UtcNow;
        await _dataset.AddAsync(entity);
        await _context.SaveChangesAsync();
      }

      catch (Exception ex)
      {
        throw new Exception("Erro ao inserir.", ex);
      }

      return entity;
    }

    public async Task<Table> SelectAsync(Guid id)
    {
      try
      {
        return await _dataset.SingleOrDefaultAsync(p => p.Id.Equals(id));
      }
      catch (Exception ex)
      {
        throw new Exception("Erro ao selecionar.", ex);
      }
    }

    public async Task<IEnumerable<Table>> SelectAsync()
    {
      try
      {
        return await _dataset.ToListAsync();
      }
      catch (Exception ex)
      {
        throw new Exception("Erro ao selecionar.", ex);
      }
    }

    public async Task<Table> UpdateAsync(Table entity)
    {
      try
      {
        var result = await _dataset.SingleOrDefaultAsync(p => p.Id.Equals(entity.Id));

        if (result == null)
        {
          return null;
        }

        entity.UpdatedAt = DateTime.UtcNow;
        entity.CreatedAt = result.CreatedAt;

        _context.Entry(result).CurrentValues.SetValues(entity);
        await _context.SaveChangesAsync();
      }

      catch (Exception ex)
      {
        throw new Exception("Erro ao atualizar.", ex);
      }

      return entity;
    }
  }
}