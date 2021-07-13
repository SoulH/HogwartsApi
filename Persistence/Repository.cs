using Core.Entities;
using Core.Persistence;
using Core.Utils;
using EFPersistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Persistence
{
    public class Repository : IRepository
    {
        private HogwartsDbContext context;

        public Repository(HogwartsDbContext ctx)
        {
            this.context = ctx;
        }

        public IEnumerable<T> Find<T>(Func<T, bool> query = null) where T : Entity
        {
            if (query is null) query = e => true;
            return context.Set<T>().Where(query);
        }

        public T Get<T>(Guid id) where T : Entity
        {
            return context.Set<T>().FirstOrDefault(e => e.Id == id);
        }

        public bool Remove<T>(Guid id) where T : Entity
        {
            var entity = Get<T>(id);
            if (entity is null) return false;
            context.Set<T>().Remove(entity);
            return true;
        }

        public bool Remove<T>(T entity) where T : Entity
        {
            context.Set<T>().Remove(entity);
            return true;
        }

        public bool Remove<T>(IEnumerable<T> entities) where T : Entity
        {
            context.Set<T>().RemoveRange(entities.ToArray());
            return true;
        }

        public bool Save() => context.SaveChanges() > 0;

        public T Set<T>(T entity) where T : Entity
        {
            var saved = context.Set<T>().FirstOrDefault(e => e.Id == entity.Id);
            if (saved != null)
                saved.MergeWith(entity);
            context.Set<T>().Add(entity);
            return entity;
        }

        public IEnumerable<T> Set<T>(IEnumerable<T> entitities) where T : Entity
        {
            foreach (T entity in entitities)
                Set(entity);
            return entitities;
        }

        
    }
}
