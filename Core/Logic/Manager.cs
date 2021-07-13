using Core.Models;
using Core.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Logic
{
    public abstract class Manager
    {
        protected IRepository _repository;

        public Manager(IRepository repository)
        {
            this._repository = repository;
        }

        public ResponseData<T> Success<T>(IEnumerable<T> result, string message = null)
        {
            return ResponseData<T>.Ok(result, message);
        }

        public ResponseData<T> Success<T>(T result, string message = null)
        {
            return ResponseData<T>.Ok(result, message);
        }

        public ResponseData<T> Error<T>(IDictionary<string, string[]> detail = null, string message = null)
        {
            return ResponseData<T>.Error(detail, message);
        }

        /// <summary>
        /// Ejecuta una o mas instrucciones ignorando los cambios en caso de error
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="todo">Función a ejecutar</param>
        /// <returns></returns>
        public ResponseData<T> Exec<T>(Func<IRepository, ResponseData<T>> todo)
        {
            try
            {
                var res = todo(this._repository);
                _repository.Save();
                return res;
            }
            catch(Exception e)
            {
                var err = new Dictionary<string, string[]>();
                err["Exception"] = new string[] { e.Message };
                err["Source"] = new string[] { e.Source };
                return Error<T>(err, "Unexpected Error");
            }
        }
    }
}
