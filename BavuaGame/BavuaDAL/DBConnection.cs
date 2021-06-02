using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BavuaDAL
{
    public class DBConnection
    {
        public List<T> GetDbSet<T>() where T : class
        {
            using (BavuaEntities bavuaEntities1 = new BavuaEntities())
            {
                return bavuaEntities1.Set<T>().ToList();
            }
        }

        public enum ExecuteAction
        {
            Insert,
            Update,
            Delete
        }
        public void Execute<T>(T entity, ExecuteAction exAction) where T : class
        {
            using (BavuaEntities bavuaEntities1 = new BavuaEntities())
            {
                var model = bavuaEntities1.Set<T>();
                switch (exAction)
                {
                    case ExecuteAction.Insert:
                        model.Add(entity);
                        break;
                    case ExecuteAction.Update:
                        model.Attach(entity);
                        bavuaEntities1.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                        break;
                    case ExecuteAction.Delete:
                        model.Attach(entity);
                        bavuaEntities1.Entry(entity).State = System.Data.Entity.EntityState.Deleted;
                        break;
                    default:
                        break;
                }
                bavuaEntities1.SaveChanges();
            }
        }

    }
}
