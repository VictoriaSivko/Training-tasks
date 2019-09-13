using System.Collections.Generic;

namespace DAL.Interface.Interfaces
{
    /// <summary>
    /// Basic steps for saving and retrieving data.
    /// </summary>
    /// <typeparam name="T">Type of information stored.</typeparam>
    public interface IRepository<T>
    {
        string Path { get; set; }
        List<T> ReadFile(List<T> list);
        void WriteFile(List<T> list);
    }
}
