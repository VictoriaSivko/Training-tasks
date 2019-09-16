namespace FileCabinetLib.Interfaces
{
    /// <summary>
    /// Search interface for objects corresponding to a certain condition.
    /// </summary>
    /// <typeparam name="T">Type of object to search.</typeparam>
    public interface IFinder<T>
    {
        bool Find(T obj);
    }
}
