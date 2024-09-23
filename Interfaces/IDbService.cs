namespace Anime_store.Interfaces
{
    public interface IDbService<T> where T : class
    {
        /// <summary>
        /// Creates a new T entity in the database
        /// </summary>
        /// <param name="entity"> The entity to be created </param>
        /// <returns> The number of entities added </returns>
        Task<bool> Create(T entity);

        /// <summary>
        /// Gets all T entities from the database
        /// </summary>
        /// <returns> A list of T entities </returns>
        Task<List<T>> GetAll();

        /// <summary>
        /// Gets a T entity from the database by its ID
        /// </summary>
        /// <param name="id"> The ID of the entity to get </param>
        /// <returns> The entity with the specified ID </returns>
        Task<T?> Get(int id);

        /// <summary>
        /// Updates a T entity in the database
        /// </summary>
        /// <param name="entity"> The entity to be updated </param>
        /// <returns> The boolean value indicating whether the entity was updated </returns>
        Task<bool> Update(T entity);

        /// <summary>
        /// Deletes a T entity from the database by its ID
        /// </summary>
        /// <param name="id"> The ID of the entity to delete </param>
        /// <returns> The boolean value indicating whether the entity was deleted </returns>
        Task<bool> Delete(int id);
    }
}
