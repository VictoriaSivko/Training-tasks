namespace BLL.Interface.Interfaces
{
    /// <summary>
    /// Generate inner id.
    /// </summary>
    public interface IAccountNumberCreateService
    {
        string GenerateId(string str);
    }
}
