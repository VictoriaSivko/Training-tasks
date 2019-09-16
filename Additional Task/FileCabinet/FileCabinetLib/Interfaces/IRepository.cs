using System.Collections.Generic;

namespace FileCabinetLib.Interfaces
{
    /// <summary>
    /// Data repository.
    /// </summary>
    /// <typeparam name="T">Type of object stored in the repository.</typeparam>
    public interface IRepository<T>
    {
        void Write(List<T> list);
        List<T> Reade();
    }
}
