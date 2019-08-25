using System.Collections.Generic;

namespace Books
{
    public interface IFinder<T>
    {
        bool Find(Book book);
    }
}
