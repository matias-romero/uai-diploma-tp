using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using Dapper;

namespace SaludAr.DAL.Internal
{
    internal interface IEntityRawSql
    {
        IEnumerable<T> ExecuteQuery<T>(string sql, object param);
        T ExecuteScalar<T>(string sql, object param);
        int ExecuteSql(string sql, object param);
    }

    internal class EntityRawSql : IEntityRawSql
    {
        private readonly string _cnnString;
        private readonly DbProviderFactory _databaseProviderFactory;

        public EntityRawSql(DbProviderFactory databaseProviderFactory, string cnnString)
        {
            _databaseProviderFactory = databaseProviderFactory;
            _cnnString = cnnString;
        }

        public IEnumerable<T> ExecuteQuery<T>(string sql, object param)
        {
            List<T> queryResult;
            using (var connection = this.GetNewConnection())
                queryResult = connection.Query<T>(sql, param).ToList();

            return queryResult;
        }

        public T ExecuteScalar<T>(string sql, object param)
        {
            using (var connection = this.GetNewConnection())
                return connection.ExecuteScalar<T>(sql, param);
        }

        public int ExecuteSql(string sql, object param)
        {
            using (var connection = this.GetNewConnection())
                return connection.Execute(sql, param);
        }

        private IDbConnection GetNewConnection()
        {
            var connection = _databaseProviderFactory.CreateConnection();
            connection.ConnectionString = _cnnString;
            return connection;
        }
    }
}
