using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Entities;
using Entities.Model;
using MongoDB.Bson;

namespace Data
{
    public interface IMongoRepository<T> where T : EntityBase, new()
    {
        Task DeleteById(string id);

        IMongoQueryable<T> Query { get; set; }

        Task<IEnumerable<T>> GetMany(Expression<Func<T, bool>> expression);

        Task<IEnumerable<T>> GetAll();

        Task<T> GetOne(string id);

        Task<T> FindOneAndUpdate(Expression<Func<T, bool>> expression, UpdateDefinition<T> update, FindOneAndUpdateOptions<T> option);

        Task UpdateOne(Expression<Func<T, bool>> expression, T update);

        Task DeleteOne(Expression<Func<T, bool>> expression);

        Task InsertMany(IEnumerable<T> items);

        Task InsertOne(T item);
    }
}
