using Core.Models;
using Core.Persistence;
using System;
using System.Collections.Generic;

namespace Core.Logic
{
    public static class EnrollmentExtensions
    {
        public static Registration NewRecord(this IRepository repository, Registration data)
        {
            return repository.Set(data);
        }

        public static Registration UpdateRecord(this IRepository repository, Registration data)
        {
            return repository.Set(data);
        }

        public static bool DeleteRecord(this IRepository repository, Guid id)
        {
            return repository.Remove<Registration>(id);
        }

        public static bool DeleteRecord(this IRepository repository, Registration data)
        {
            return repository.Remove<Registration>(data.Id);
        }

        public static IEnumerable<Registration> GetRecords(this IRepository repository, Func<Registration, bool> query = null)
        {
            return repository.Find(query);
        }
    }
}
