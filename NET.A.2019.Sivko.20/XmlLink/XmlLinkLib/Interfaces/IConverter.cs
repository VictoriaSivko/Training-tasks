namespace XmlLinkLib.Interfaces
{
    public interface IConverter<Tsource, Tresult>
    {
        Tresult Convert(Tsource source);
    }
}
