using PostgreSQL.Entities;
using System.Collections.Generic;

namespace PostgreSQL.Service
{
    public interface IService<T> where T : class
    {
        EntityResult<T> Insert(T entities);
        EntityResult<T> Update(T entities);
        EntityResult<T> Delete(T entities);
        EntityResult<T> GetById(int id);
        EntityResult<T> GetList();
    }
}
