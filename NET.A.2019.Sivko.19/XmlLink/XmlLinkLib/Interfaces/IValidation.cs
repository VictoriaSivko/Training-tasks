namespace XmlLinkLib.Interfaces
{
    public interface IValidation<T>
    {
        bool Valid(T item);
    }
}
