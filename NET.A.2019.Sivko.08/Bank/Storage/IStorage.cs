using System.Collections.Generic;

namespace Bank
{
    public interface IStorage<T>
    {
        string Path { get; set; }
        List<T> ReadFile(List<T> list);
        void WriteFile(List<T> list);
    }
}
