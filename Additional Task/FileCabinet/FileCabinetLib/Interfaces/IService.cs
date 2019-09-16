namespace FileCabinetLib.Interfaces
{
    /// <summary>
    /// Contains the methods of the service.
    /// </summary>
    /// <typeparam name="T">Type of service object.</typeparam>
    public interface IService<T>
    {
        void Add(T item);
        void Remove(int index);
        void Clear();
    }
}
