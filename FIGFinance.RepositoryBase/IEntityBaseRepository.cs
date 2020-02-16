using FIGFiance.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FIGFinance.RepositoryBase
{
    /// <summary>
    /// repository 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IEntityBaseRepository<T> where T : class, IEntityBase, new()
    {
        IQueryable<T> GetAll(string query);
        T GetDetail(string id);        
    }
}
