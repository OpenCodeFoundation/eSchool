using eSchool.Infrastructure.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace eSchool.Infrastructure.Repository
{
    public class MongoRepository : IRepository
    {
        public void Delete<T>(Expression<Func<T, bool>> dataFilters)
        {
            throw new NotImplementedException();
        }

        public void Delete<T>(Expression<Func<T, bool>> dataFilters, string collectionName)
        {
            throw new NotImplementedException();
        }

        public string ExecuteCommand(string query)
        {
            throw new NotImplementedException();
        }

        public T GetItem<T>(Expression<Func<T, bool>> dataFilters)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> GetItems<T>(Expression<Func<T, bool>> dataFilters)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> GetItems<T>()
        {
            throw new NotImplementedException();
        }

        public void Initialize()
        {
            throw new NotImplementedException();
        }

        public void Save<T>(T data, string collectionName = "")
        {
            throw new NotImplementedException();
        }

        public void Save<T>(List<T> datas)
        {
            throw new NotImplementedException();
        }

        public void Update<T>(Expression<Func<T, bool>> dataFilters, T data)
        {
            throw new NotImplementedException();
        }

        public void UpdateMany<T>(Expression<Func<T, bool>> dataFilters, object data, string collectionName = "")
        {
            throw new NotImplementedException();
        }
    }
}
