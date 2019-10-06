namespace Data
{
    using MongoDB.Driver;
    using MongoDB.Driver.Linq;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using Entities;
    using Entities.Model;

    public class MongoRepository<T> : IMongoRepository<T> where T : EntityBase, new()
    {
        private readonly string collectionName;

        private readonly IMongoDatabase db;

        public MongoRepository()
        {
            this.collectionName = typeof(T).Name;

            //db = server.GetDatabase(MongoUrl.Create(connectionString).DatabaseName);
            this.db = ConnectionCosmosMongoDb.DataBase;
        }

        protected IMongoCollection<T> Collection
        {
            get
            {
                return this.db.GetCollection<T>(this.collectionName);
            }
            set
            {
                this.Collection = value;
            }
        }

        public IMongoQueryable<T> Query
        {
            get
            {
                return this.Collection.AsQueryable<T>();
            }
            set
            {
                this.Query = value;
            }
        }

        public async Task<T> GetOne(Expression<Func<T, bool>> expression)
        {
            return await this.Collection.Find(expression).SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<T>> GetMany(Expression<Func<T, bool>> expression)
        {
            return await this.Collection.Find(expression).ToListAsync();
        }

        public async Task<T> FindOneAndUpdate(Expression<Func<T, bool>> expression, UpdateDefinition<T> update, FindOneAndUpdateOptions<T> option)
        {
            return await this.Collection.FindOneAndUpdateAsync(expression, update, option);
        }

        public async Task UpdateOne(Expression<Func<T, bool>> expression, T update)
        {
            await this.Collection.ReplaceOneAsync(expression, update);
        }

        public async Task DeleteOne(Expression<Func<T, bool>> expression)
        {
            await this.Collection.DeleteOneAsync(expression);
        }

        public async Task InsertMany(IEnumerable<T> items)
        {
            await this.Collection.InsertManyAsync(items);
        }

        public async Task InsertOne(T item)
        {
            await this.Collection.InsertOneAsync(item);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await this.Collection.Find(x => 1 == 1).ToListAsync();
        }
    }
}
