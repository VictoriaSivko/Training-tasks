namespace BookLib
{
    /// <summary>
    /// Search interface for objects corresponding to a certain condition.
    /// </summary>
    /// <typeparam name="T">Type of object to search.</typeparam>
    public interface IFinder<T>
    {
        /// <summary>
        /// Checks whether the object meets a certain criterion.
        /// </summary>
        /// <param name="obj">Object to check for matching the search criteria.</param>
        /// <returns>True or False depending on whether the object matches the search criteria.</returns>
        bool Find(T obj);
    }
}
