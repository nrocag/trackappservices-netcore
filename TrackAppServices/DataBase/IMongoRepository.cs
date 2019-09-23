using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TrackAppServices.Entities;

namespace TrackAppServices.DataBase
{
    public interface IMongoRepository<T> where T : EntityBase, new()
    {
        IMongoQueryable<T> Query { get; set; }

        Task<IEnumerable<T>> GetMany(Expression<Func<T, bool>> expression);

        Task<IEnumerable<T>> GetAll();

        Task<T> GetOne(Expression<Func<T, bool>> expression);

        Task<T> FindOneAndUpdate(Expression<Func<T, bool>> expression, UpdateDefinition<T> update, FindOneAndUpdateOptions<T> option);

        void UpdateOne(Expression<Func<T, bool>> expression, T update);

        void DeleteOne(Expression<Func<T, bool>> expression);

        void InsertMany(IEnumerable<T> items);

        void InsertOne(T item);
    }
}
