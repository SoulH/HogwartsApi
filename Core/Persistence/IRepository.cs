using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Persistence
{
    public interface IRepository
    {

        T Get<T>(Guid id) where T : Entity;

        /// <summary>
        /// Insert or Update one entity
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        T Set<T>(T entity) where T : Entity;

        /// <summary>
        /// Insert Or Update many entities
        /// </summary>
        /// <param name="entitities"></param>
        /// <returns></returns>
        IEnumerable<T> Set<T>(IEnumerable<T> entitities) where T : Entity;

        /// <summary>
        /// Devuelve todas las entidades coincidentes el query. 
        /// Si query es null retorna todas las entidades.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <returns></returns>
        IEnumerable<T> Find<T>(Func<T, bool> query = null) where T : Entity;

        bool Remove<T>(Guid id) where T : Entity;

        bool Remove<T>(T entity) where T : Entity;

        bool Remove<T>(IEnumerable<T> entities) where T : Entity;

        bool Save();
    }
}
