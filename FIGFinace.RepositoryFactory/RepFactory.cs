using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using FIGFinance.RepositoryBase;
using FIGFiance.Entities;
using FIGFinance.GoogleRepositoryImpl;

namespace FIGFinace.RepositoryFactory
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class RepFactory<T>
           where T : class, IEntityBase, new()
    {
        public static IEntityBaseRepository<T> CreateEntityRepository(string entity)
        {
            IEntityBaseRepository<T> _entityrepo;
            switch (entity)
            {
                case "GOOGLE":
                    return _entityrepo = new GooglBookApi<T>();
                default:
                return null;
            }
        }
    }
}
