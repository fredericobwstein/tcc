﻿namespace AnimecatalogAPI.Core.Repository
{
    public interface IRepositoryBase
    {
        IEnumerable<T> GetAll<T>() where T : class;
        IEnumerable<T> GetAll<T>(object obj = null) where T : class;
        IEnumerable<T> Query<T>(string sql, object obj = null) where T : class;
        T GetById<T>(Guid codigo) where T : class;
        void Insert<T>(T entity);
        void Update<T>(T entity);
        void Delete<T>(T entity);
    }
}
