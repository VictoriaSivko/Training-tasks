namespace XmlLinkLib.Interfaces
{
    public interface IRepository<T>
    {
        void Write(T item);
        T Read();
    }
}
