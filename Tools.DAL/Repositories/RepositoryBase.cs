using System.Data;
using Tools.DAL.Interfaces;

namespace Tools.DAL.Repositories
{
    public abstract class RepositoryBase<TKey, TEntity> : IRepository<TKey, TEntity>
            where TEntity : class, IEntity<TKey>
    {
        protected IDbConnection _Connection;

        public string TableName { get; init; }
        public string ColumnIdName { get; init; }

        public RepositoryBase(IDbConnection connection, string tableName, string columnIdName)
        {
            _Connection = connection;
            TableName = tableName;
            ColumnIdName = columnIdName;
        }

        public void ConnectionOpen()
        {
            if (_Connection.State == ConnectionState.Open)
            {
                _Connection.Close();

            }
            _Connection.Open();

        }

        protected void AddParameter(IDbCommand cmd, string name, object data)
        {
            IDbDataParameter param = cmd.CreateParameter();
            param.ParameterName = name;
            param.Value = data ?? DBNull.Value;
            cmd.Parameters.Add(param);
        }

        protected abstract TEntity Convert(IDataRecord record);

        #region CRUD
        public virtual IEnumerable<TEntity> GetAll()
        {
            using (IDbCommand cmd = _Connection.CreateCommand())
            {
                cmd.CommandText = $"SELECT * FROM {TableName}";

                _Connection.Open();
                using (IDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        yield return Convert(reader);
                    }
                }
                _Connection.Close();
            }
        }

        public virtual TEntity GetById(TKey id)
        {
            using (IDbCommand cmd = _Connection.CreateCommand())
            {
                cmd.CommandText = $"SELECT * FROM {TableName} WHERE {ColumnIdName} = @id";
                AddParameter(cmd, "@id", id);

                _Connection.Open();
                using (IDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read()) return Convert(reader);
                    throw new ArgumentNullException($"Element {TableName} inexistant");
                }
            }
        }

        public abstract TKey Insert(TEntity entity);

        public abstract bool Update(TKey id, TEntity entity);

        public virtual bool Delete(TKey id)
        {
            using (IDbCommand cmd = _Connection.CreateCommand())
            {
                cmd.CommandText = $"DELETE FROM {TableName} WHERE {ColumnIdName} = @id";
                AddParameter(cmd, "@id", id);

                _Connection.Open();
                return cmd.ExecuteNonQuery() == 1;
            }
        }
        #endregion
    }
}
