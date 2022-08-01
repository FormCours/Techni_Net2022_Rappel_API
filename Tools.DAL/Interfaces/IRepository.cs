namespace Tools.DAL.Interfaces
{
    public interface IRepository<TKey, TEntity>
        where TEntity : class, IEntity<TKey>   
    {
        // Create
        TKey Insert(TEntity entity);

        // Read
        IEnumerable<TEntity> GetAll();
        TEntity GetById(TKey key);

        // Update
        bool Update(TKey id, TEntity entity);

        // Delete
        bool Delete(TKey id);

        // Delete by Entity (Implementation par default)
        bool Delete(TEntity entity)
        {
            return Delete(entity.Id);
        }
    }
}
