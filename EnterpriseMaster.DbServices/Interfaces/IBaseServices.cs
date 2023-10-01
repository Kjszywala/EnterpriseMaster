namespace EnterpriseMaster.DbServices.Interfaces
{
    public interface IBaseServices<T>
        where T : class
    {
        /// <summary>
        /// Get all items from database.
        /// </summary>
        /// <param name="Item">Model</param>
        /// <returns>List of active items</returns>
        Task<List<T>> GetAllAsync();

        /// <summary>
        /// Get item with the given id from database.
        /// </summary>
        /// <param name="id">Item Id</param>
        /// <returns>Item with given Id</returns>
        Task<T> GetAsync(int id);

        /// <summary>
        /// Add item to database.
        /// </summary>
        /// <param name="Item">Model</param>
        /// <returns>True if operation completed, else false</returns>
        Task<bool> AddAsync(T Item);

        /// <summary>
        /// Remove item from database.
        /// </summary>
        /// <param name="Id">Item Id</param>
        /// <returns>True if operation completed, else false</returns>
        Task<bool> RemoveAsync(int Id);

        /// <summary>
        /// Edit item in database.
        /// </summary>
        /// <param name="Id">Item Id</param>
        /// <param name="Item">Item</param>
        /// <returns>True if operation completed, else false</returns>
        Task<bool> EditAsync(int Id, T Item);
    }
}
