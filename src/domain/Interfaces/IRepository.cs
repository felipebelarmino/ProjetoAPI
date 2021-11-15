using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using domain.Entities;

namespace domain.Interfaces
{
  public interface IRepository<Table> where Table : BaseEntity
  {
    Task<Table> InsertAsync(Table entity);
    Task<Table> UpdateAsync(Table entity);
    Task<bool> DeleteAsync(Guid id);
    Task<Table> SelectAsync(Guid id);
    Task<IEnumerable<Table>> SelectAsync();
    Task<bool> ExistAsync(Guid id);
  }
}