using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TenantsAssociation.DataAccess.IRepository
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        void Delete(object id);
        IQueryable<TEntity> GetAll();
        Task InsertAsync(TEntity entity);
        void Update(TEntity entityToUpdate);
    }
}