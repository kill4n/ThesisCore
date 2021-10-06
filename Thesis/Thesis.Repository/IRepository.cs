using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Thesis.Repository
{
    public interface IRepository<TEntity>
    {
        IEnumerable<TEntity> Get();
        TEntity Get(int id);
        void Add(TEntity data);
        void Delete(int id);
        void Update(TEntity data);
        void Save();
    }
}
